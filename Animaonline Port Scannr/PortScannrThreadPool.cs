using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Threading;

namespace Animaonline.Network
{
    interface IThreadPool : IDisposable
    {
        void QueueUserWorkItem(WaitCallback work, object obj);
    }

    public class PortScannrThreadPool : IThreadPool
    {
        public void QueueUserWorkItem(WaitCallback work, object obj)
        {
            ThreadPool.QueueUserWorkItem(work, obj);
        }

        public void Dispose() { }
    }

    public class PortScannrLockThreadPool : IThreadPool
    {
        public PortScannrLockThreadPool() :
            this(Environment.ProcessorCount, true) { }

        public PortScannrLockThreadPool(int concurrencyLevel) :
            this(concurrencyLevel, true) { }

        public PortScannrLockThreadPool(bool flowExecutionContext) :
            this(Environment.ProcessorCount, flowExecutionContext) { }

        public PortScannrLockThreadPool(int concurrencyLevel, bool flowExecutionContext)
        {
            if (concurrencyLevel <= 0)
                throw new ArgumentException("concurrencyLevel");

            m_concurrencyLevel = concurrencyLevel;
            m_flowExecutionContext = flowExecutionContext;

            if (!flowExecutionContext)
                new SecurityPermission(SecurityPermissionFlag.Infrastructure).Demand();
        }

        struct WorkItem
        {
            internal WaitCallback m_work;
            internal object m_obj;
            internal ExecutionContext m_executionContext;

            internal WorkItem(WaitCallback work, object obj)
            {
                m_work = work;
                m_obj = obj;
                m_executionContext = null;
            }

            internal void Invoke()
            {
                if (m_executionContext == null)
                    m_work(m_obj);
                else
                    ExecutionContext.Run(m_executionContext, ContextInvoke, null);
            }
            private void ContextInvoke(object obj)
            {
                m_work(m_obj);
            }
        }

        private readonly int m_concurrencyLevel;
        private readonly bool m_flowExecutionContext;
        private readonly Queue<WorkItem> m_queue = new Queue<WorkItem>();
        private Thread[] m_threads;
        private int m_threadsWaiting;
        private bool m_shutdown;

        public void QueueUserWorkItem(WaitCallback work)
        {
            QueueUserWorkItem(work, null);
        }

        public void QueueUserWorkItem(WaitCallback work, object obj)
        {
            WorkItem wi = new WorkItem(work, obj);
            if (m_flowExecutionContext)

                wi.m_executionContext = ExecutionContext.Capture();

            EnsureStarted();

            lock (m_queue)
            {
                m_queue.Enqueue(wi);
                if (m_threadsWaiting > 0)
                    Monitor.Pulse(m_queue);
            }
        }

        private void EnsureStarted()
        {
            if (m_threads == null)
            {
                lock (m_queue)
                {
                    if (m_threads == null)
                    {
                        m_threads = new Thread[m_concurrencyLevel];
                        for (int i = 0; i < m_threads.Length; i++)
                        {
                            m_threads[i] = new Thread(DispatchLoop);
                            m_threads[i].Start();
                        }
                    }
                }
            }
        }

        private void DispatchLoop()
        {
            while (true)
            {
                WorkItem wi = default(WorkItem);
                lock (m_queue)
                {
                    if (m_shutdown)
                        return;
                    while (m_queue.Count == 0)
                    {
                        m_threadsWaiting++;
                        try { Monitor.Wait(m_queue); }
                        finally { m_threadsWaiting--; }
                        if (m_shutdown)
                            return;
                    }
                    wi = m_queue.Dequeue();
                }
                wi.Invoke();
            }
        }

        public void Dispose()
        {
            m_shutdown = true;
            lock (m_queue)
            {
                Monitor.PulseAll(m_queue);
            }
            for (int i = 0; i < m_threads.Length; i++)
                m_threads[i].Join();
        }
    }
}
