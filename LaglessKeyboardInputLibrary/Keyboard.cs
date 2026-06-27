using System.Runtime.InteropServices;

namespace LaglessKeyboardInput
{
    public static class Keyboard
    {
        private const int KEY_DOWN_STATE = 0x8000;
        private static readonly Dictionary<int, string> keyCodes = new Dictionary<int, string>{
    // Mouse Buttons
    { 0x01, "LEFT_MOUSE" },
    { 0x02, "RIGHT_MOUSE" },
    { 0x04, "MIDDLE_MOUSE" },
    { 0x05, "MOUSE_4" },
    { 0x06, "MOUSE_5" },

    // Control Keys
    { 0x08, "BACKSPACE" },
    { 0x09, "TAB" },
    { 0x0C, "CLEAR" },
    { 0x0D, "RETURN" },
    { 0x10, "SHIFT" },
    { 0x11, "CONTROL" },
    { 0x12, "ALT" },
    { 0x14, "CAPS_LOCK" },
    { 0x1B, "ESCAPE" },
    { 0x20, "SPACE" },

    // Navigation Keys
    { 0x25, "LEFT_ARROW" },
    { 0x26, "UP_ARROW" },
    { 0x27, "RIGHT_ARROW" },
    { 0x28, "DOWN_ARROW" },

    // Numbers 0-9
    { 0x30, "0" }, { 0x31, "1" }, { 0x32, "2" }, { 0x33, "3" }, { 0x34, "4" },
    { 0x35, "5" }, { 0x36, "6" }, { 0x37, "7" }, { 0x38, "8" }, { 0x39, "9" },

    // Letters A-Z
    { 0x41, "A" }, { 0x42, "B" }, { 0x43, "C" }, { 0x44, "D" }, { 0x45, "E" },
    { 0x46, "F" }, { 0x47, "G" }, { 0x48, "H" }, { 0x49, "I" }, { 0x4A, "J" },
    { 0x4B, "K" }, { 0x4C, "L" }, { 0x4D, "M" }, { 0x4E, "N" }, { 0x4F, "O" },
    { 0x50, "P" }, { 0x51, "Q" }, { 0x52, "R" }, { 0x53, "S" }, { 0x54, "T" },
    { 0x55, "U" }, { 0x56, "V" }, { 0x57, "W" }, { 0x58, "X" }, { 0x59, "Y" },
    { 0x5A, "Z" },

    // Function Keys
    { 0x70, "F1" }, { 0x71, "F2" }, { 0x72, "F3" }, { 0x73, "F4" },
    { 0x74, "F5" }, { 0x75, "F6" }, { 0x76, "F7" }, { 0x77, "F8" },
    { 0x78, "F9" }, { 0x79, "F10" }, { 0x7A, "F11" }, { 0x7B, "F12" },

    // Misc
    { 0x90, "NUM_LOCK" },
    { 0x91, "SCROLL_LOCK" },
    { 0xA0, "LEFT_SHIFT" },
    { 0xA1, "RIGHT_SHIFT" },
    { 0xA2, "LEFT_CONTROL" },
    { 0xA3, "RIGHT_CONTROL" },
    { 0xBA, "SEMICOLON" },
    { 0xBB, "PLUS" },
    { 0xBC, "COMMA" },
    { 0xBD, "MINUS" },
    { 0xBE, "FULL_STOP" },
    { 0xBF, "FORWARD_SLASH" },
};
        [DllImport("user32.dll", SetLastError = true)] private static extern short GetAsyncKeyState(int vKey);
        [DllImport("user32.dll")] private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")] private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        private static bool WindowFocused()
        {
            IntPtr foregroundWindow = GetForegroundWindow();
            if (foregroundWindow == IntPtr.Zero) return false;

            GetWindowThreadProcessId(foregroundWindow, out int activeProcessId);

            // This check works for standard users perfectly
            return activeProcessId == Environment.ProcessId;
        }
        public static bool CurrentKey(out List<string> key)
        {
            key = new List<string>();
            //if (!WindowFocused()) { key = new List<string>(); return false; }
            foreach (int i in keyCodes.Keys)
            {
                if ((GetAsyncKeyState(i) & KEY_DOWN_STATE) != 0)
                {
                    key.Add(keyCodes[i]);
                }
            }
            return key.Count > 0;
        }
    }
}
