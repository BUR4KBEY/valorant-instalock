using System.Threading;
using valorant_instalock.Classes.Helpers;

namespace valorant_instalock.Classes
{
    internal static class MouseController
    {
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

        internal static void LeftClick()
        {
            User32.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(20);
            User32.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        internal static void MoveAndLeftClick(int x, int y)
        {
            User32.SetCursorPos(x, y);
            Thread.Sleep(10);
            LeftClick();
        }
    }
}
