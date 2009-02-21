using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Animaonline
{
    [CLSCompliant(false)]
    public class WindowsApi
    {
        public class Kernel32
        {
            /// <summary>
            /// Shows the Console Window
            /// </summary>
            [DllImport("kernel32")]
            private static extern bool AllocConsole();
            public static bool ShowConsole()
            {
                return AllocConsole();
            }
            /// <summary>
            /// Hides the Console Window
            /// </summary>
            [DllImport("kernel32")]
            private static extern bool FreeConsole();
            public static bool CloseConsole()
            {
                bool v = FreeConsole();
                if (v)
                {

                }
                return v;
            }


            [DllImport("kernel32")]
            public static extern bool SetConsoleTitle(string lpConsoleTitle);
        }

        public class User32
        {
            /// <summary>
            /// Shows a MessageBox using Windows API
            /// </summary>
            /// <param name="h">0</param>
            /// <param name="m">Body</param>
            /// <param name="c">Caption</param>
            /// <param name="type">0</param>
            [DllImport("User32.dll")]
            public static extern int MessageBox(int h, string m, string c, int type);

            public enum BeepType
            {
                SimpleBeep = -1,
                SystemAsterisk = 0x00000040,
                SystemExclamation = 0x00000030,
                SystemHand = 0x00000010,
                SystemQuestion = 0x00000020,
                SystemDefault = 0
            }

            /// <summary>
            /// Beeps
            /// </summary>
            /// <param name="beepType">0</param>
            [DllImport("User32.dll")]
            public static extern Boolean MessageBeep(BeepType beepType);

            [DllImport("user32.dll")]
            public static extern IntPtr SetFocus(IntPtr hWnd);

            [DllImport("user32.dll")]
            public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

            [DllImport("user32.dll")]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

            [DllImport("User32.dll")]
            public static extern bool ReleaseCapture();

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr FindWindow(string strClassName, string strWindowName);

            [DllImport("User32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
            public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, UInt32 wParam, UInt32 lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, UInt32 wParam, string lParam);
        }
    }
}
