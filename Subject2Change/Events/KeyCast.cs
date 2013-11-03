using System;
using SFML.Window;

namespace Subject2Change
{
    class GameKeys
    {
        /// <summary>
        /// Casting char to Keyboard.Key.
        /// </summary>
        /// <param name="key">The char that we need the Key value of.</param>
        /// <returns>The Key value of our char 'key'.</returns>
        public static Keyboard.Key Cast(char key)
        {
            return (Keyboard.Key)key;
            
        }

        /// <summary>
        /// Casting string to Keybaord.Key.
        /// </summary>
        /// <param name="key">The string we need the Key value of.</param>
        /// <returns>The Key value of our string "key".</returns>
        public static Keyboard.Key Cast(string key)
        {
            return (Keyboard.Key)Enum.Parse(typeof(Keyboard.Key), key);
        }

        /// <summary>
        /// Get the key on given line.
        /// </summary>
        /// <param name="line">String of the line we need a key from.</param>
        /// <returns>returns the key as a String.</returns>
        public static string GetKeyFrom(string line)
        {
            if (line.Contains(":")) return line.Substring(0, line.LastIndexOf(':'));
            return "Unknown";
        }

        public readonly static Keyboard.Key[] AllKeys 
            = (Keyboard.Key[])Enum.GetValues(typeof(Keyboard.Key));
    }
}