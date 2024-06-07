using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Utils
{
    public static class KeyboardHelper
    {
        public enum KeyMap { ESC,Left,Right,Up,Down }


        public static bool KeyDown(KeyMap keyMap)
        {
            return Input.IsActionJustPressed(keyMap.ToString());
        }
    }
}
