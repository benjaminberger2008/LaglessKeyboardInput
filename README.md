# Lagless Keyboard Input Library

C# library designed to bypass standard terminal input lag and handle real-time input tracking within the terminal. 
Supports hardware-level multi-key polling at sub-millisecond execution speeds.

## Usage
```csharp
using LaglessKeyboardInput;
```
```csharp
List<string> currentKeys; // Store the list of active keys pressed

if (Keyboard.CurrentKey(out currentKeys)) // returns true if any key is held, and returns List of keys pressed
{
    if (currentKeys.Contains("ESCAPE")) // Check if Escape was pressed when Keyboard.CurrentKey(); was executed
    {
        Console.WriteLine("Escape pressed!");
    }
}
```
## Key Aliases

Pass these exact strings into your `.Contains()` check:

| Category | Key Code Strings |
| :--- | :--- |
| **Movement & Navigation** | `"UP_ARROW"`, `"DOWN_ARROW"`, `"LEFT_ARROW"`, `"RIGHT_ARROW"` |
| **Control Keys** | `"SPACE"`, `"RETURN"`, `"BACKSPACE"`, `"TAB"`, `"ESCAPE"`, `"CLEAR"` |
| **Modifiers** | `"SHIFT"`, `"CONTROL"`, `"ALT"`, `"LEFT_SHIFT"`, `"RIGHT_SHIFT"`, `"LEFT_CONTROL"`, `"RIGHT_CONTROL"`, `"CAPS_LOCK"`, `"SCROLL_LOCK"`, `"NUM_LOCK"` |
| **Mouse Buttons** | `"LEFT_MOUSE"`, `"RIGHT_MOUSE"`, `"MIDDLE_MOUSE"`, `"MOUSE_4"`, `"MOUSE_5"` |
| **Alphanumeric** | `"A"` through `"Z"`, `"0"` through `"9"` |
| **Function Keys** | `"F1"` through `"F12"` |
| **Punctuation & Misc** | `"SEMICOLON"`, `"PLUS"`, `"MINUS"`, `"COMMA"`, `"FULL_STOP"`, `"FORWARD_SLASH"` |

## Notes

Intercepts keyboard states globally across the operating system via low-level hardware hooks. Continues to capture and record keystrokes even when minimised or out of window focus.
