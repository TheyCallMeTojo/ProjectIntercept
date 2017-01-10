using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ProjectIntercept.Memory
{
    internal class WinApi
    {
        #region Nested type: HARDWAREINPUT

        [StructLayout(LayoutKind.Sequential)]
        public struct Hardwareinput
        {
            private readonly int uMsg;
            private readonly short wParamL;
            private readonly short wParamH;
        }

        #endregion

        #region Nested type: INPUT

        [StructLayout(LayoutKind.Explicit)]
        public struct Input
        {
            [FieldOffset(0)] private readonly int type;
            [FieldOffset(4)] private readonly Mouseinput mi;
            [FieldOffset(4)] private readonly Keybdinput ki;
            [FieldOffset(4)] private readonly Hardwareinput hi;
        }

        #endregion

        #region Nested type: KEYBDINPUT

        [StructLayout(LayoutKind.Sequential)]
        public struct Keybdinput
        {
            private readonly short wVk;
            private readonly short wScan;
            private readonly int dwFlags;
            private readonly int time;
            private readonly IntPtr dwExtraInfo;
        }

        #endregion

        #region Nested type: MOUSEINPUT

        [StructLayout(LayoutKind.Sequential)]
        public struct Mouseinput
        {
            private readonly int dx;
            private readonly int dy;
            private readonly int mouseData;
            private readonly int dwFlags;
            private readonly int time;
            private readonly IntPtr dwExtraInfo;
        }

        #endregion

        #region Nested type: Win32

        public sealed class Win32
        {
            // constants information can be found in <winnt.h>
            internal const uint ProcessVmRead = (0x0010);

            [DllImport("kernel32.dll")]
            internal static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwProcessId);

            [DllImport("kernel32.dll")]
            internal static extern Int32 CloseHandle(IntPtr hObject);

            [DllImport("kernel32.dll")]
            internal static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
                                                           [In, Out] byte[] buffer, UInt32 size,
                                                           out IntPtr lpNumberOfBytesRead);

            [DllImport("kernel32.dll")]
            internal static extern Boolean WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
                                                              [In, Out] byte[] buffer, UInt32 size,
                                                              out IntPtr lpNumberOfBytesWritten);

            [DllImport("user32.dll")]
            internal static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

            [DllImport("User32.dll", SetLastError = true)]
            internal static extern int SendInput(int nInputs, ref Input pInputs, int cbSize);

            [DllImport("user32.dll", SetLastError = true)]
            internal static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

            [DllImport("user32.dll")]
            internal static extern int SendMessage(IntPtr hwnd, int message, int wParam, int lParam);

            [DllImport("user32.dll")]
            internal static extern int SetCursorPos(int x, int y);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            internal static extern int GetWindowText(int hWnd, StringBuilder lpString, int cch);

            [DllImport("user32.dll")]
            internal static extern bool EnumThreadWindows(uint dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);

            #region Nested type: EnumThreadDelegate

            internal delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

            #endregion

            // ... add more here
        }

        #endregion

        #region Nested type: Win32Consts

        public sealed class Win32Consts
        {
            // For use with the INPUT struct, see SendInput for an example
            public const int InputMouse = 0;
            public const int InputKeyboard = 1;
            public const int InputHardware = 2;
        }

        #endregion
    }
}