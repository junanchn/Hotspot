using System;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static PInvoke.User32;

namespace HotspotManager
{
    public static class WindowUtility
    {
        [DllImport("user32.dll")] static extern int GetClassName(IntPtr hWnd, StringBuilder buf, int nMaxCount);

        public delegate bool EnumThreadDelegate(IntPtr hwnd, IntPtr lParam);
        [DllImport("user32.dll")] static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);

        public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);
        [DllImport("user32.dll")] static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

        public static string GetClassName(IntPtr hWnd)
        {
            var sb = new StringBuilder(256);
            GetClassName(hWnd, sb, 256);
            return sb.ToString();
        }

        public static List<IntPtr> EnumProcessWindows(string processName)
        {
            var handles = new List<IntPtr>();

            foreach (Process process in Process.GetProcessesByName(processName))
            {
                foreach (ProcessThread thread in process.Threads)
                {
                    EnumThreadWindows(thread.Id, (hWnd, lParam) =>
                    {
                        EnumChildWindows(hWnd, (hWnd, lParam) => {
                            handles.Add(hWnd);
                            return true;
                        }, IntPtr.Zero);
                        return true;
                    }, IntPtr.Zero);
                }
            }

            return handles;
        }

        public static bool ClickProcessButton(string processName, string buttonText, bool visible = true)
        {
            bool found = false;

            foreach (var hWnd in EnumProcessWindows(processName))
            {
                if (GetClassName(hWnd) != "Button")
                    continue;
                if (GetWindowText(hWnd) != buttonText)
                    continue;
                if (visible && !IsWindowVisible(hWnd))
                    continue;
                found = true;

                PostMessage(hWnd, WindowMessage.WM_BM_CLICK, IntPtr.Zero, IntPtr.Zero);
            }

            return found;
        }
    }
}
