using System;
using SFML.Graphics;
using SFML.Window;

namespace Subject2Change
{
    class GameEventHandler
    {
        private static Keyboard.Key _lastKey;

        private static int _releasedCount;
        private static Keyboard.Key[] _pressedKeys = InitializePressedKeys();

        public static void OnKeyPressed(object sender, KeyEventArgs e)
        {
            LocalWindow = (RenderWindow) sender;
            int i = 0;
            foreach(Keyboard.Key thiskey in GameKeys.AllKeys)
            {
                if (!Keyboard.IsKeyPressed(thiskey)) continue;
                _pressedKeys[i] = thiskey;//InputMap.HandleKey(thiskey);
                i++;
                if(_lastKey != thiskey)Console.WriteLine(thiskey.ToString());
                _lastKey = thiskey;
            }
            InputMap.HandleKeyPress(_pressedKeys);

            ResetPressedKeys();
        }

        private static void ResetPressedKeys(){ResetPressedKeys(_pressedKeys);}
        private static void ResetPressedKeys(Keyboard.Key[] pressedKeys)
        {
            int i = 0;
            foreach (Keyboard.Key key in pressedKeys)
            {
                pressedKeys[i] = Keyboard.Key.Unknown;
                i++;
            }
        }

        private static Keyboard.Key[] InitializePressedKeys()
        {
            Keyboard.Key[] pressedKeys = new Keyboard.Key[GameKeys.AllKeys.Length];
            ResetPressedKeys(pressedKeys);
            return pressedKeys;
        }


        public static void OnKeyReleased(object sender, KeyEventArgs e)
        {
            InputMap.HandleKeyRelease(e.Code);
        }


        public static void OnResized(object sender, SizeEventArgs e)
        {
            LocalWindow = (RenderWindow) sender;
            LocalWindow.Size = new Vector2u(e.Width, e.Height);
// ReSharper disable PossibleLossOfFraction
            LocalWindow.SetView(new View(new Vector2f((e.Width)/2, (e.Height)/2), new Vector2f(e.Width, e.Height)));
// ReSharper restore PossibleLossOfFraction

        }
        public static RenderWindow LocalWindow { get; set; }
    }
}