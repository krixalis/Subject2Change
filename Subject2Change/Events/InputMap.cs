using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SFML.Window;
using Subject2Change.Components;

namespace Subject2Change
{
    internal class InputMap
    {
        private static readonly string[] Actions = new string[AllBindings.Bindings.Length];

        /// <summary>
        /// Override of HandleKey(Keyboard.Key)
        /// Handles whatever keys the user has pressed, looks up their use
        /// and dispatches the actions to the ActionHandler that are bound to the keys.
        /// </summary>
        /// <param name="searchKeys">All the Keys we need to search for and process afterwards.</param>
        public static void HandleKeyPress(Keyboard.Key[] searchKeys)
        {
            

            Console.WriteLine("Keys pressed:");
            foreach(Keyboard.Key key in searchKeys)
            {
                if(key != Keyboard.Key.Unknown)
                Console.WriteLine("Key - " + key);
            }

            int i = 0;
            int j = 0;
            foreach (string line in AllBindings.Bindings)
            {
                foreach(Keyboard.Key key in searchKeys)
                {
                    if (line.Contains(searchKeys[j].ToString() + ':'))
                    {
                        Actions[i] = line.Substring(line.LastIndexOf(':') + 1);
                    }
                    i++;
                    j++;
                }
                i = 0;
                j = 0;
            }

            DispatchActions(Actions);
            ResetActions();
        }

        public static void HandleKeyRelease(Keyboard.Key searchKey)
        {
            string ReleaseAction = null;
            Console.WriteLine("Keys released:");

            if (searchKey != Keyboard.Key.Unknown)
                Console.WriteLine("Key - " + searchKey);

            foreach (string line in AllBindings.Bindings)
            {
                    if (line.Contains(searchKey.ToString() + ':'))
                    {
                        ReleaseAction = line.Substring(line.LastIndexOf(':') + 1);
                    }
            }

            if(ReleaseAction != null) ActionMap.ReleaseAction(ReleaseAction);
            ResetActions();
        }



        private static void DispatchActions(string[] actions)
        {
            foreach(string action in actions)
            {
                if (action == null) break;
                ActionMap.HandleAction(action);
            }
        }

        private static bool ContainsString(string[] strArr, string str)
        {
            return strArr.Any(s => s == str);
        }

        public static void ResetActions()
        {
            int i = 0;
#pragma warning disable 168
            foreach(string action in Actions)
#pragma warning restore 168
            {
                Actions[i] = "";
                i++;
            }
        }
    }

    public class ActionKeys
    {
        public ActionKeys()
        {
            foreach (Keyboard.Key key in GameKeys.AllKeys)
            {
                foreach (string line in AllBindings.Bindings)
                {
                    if (line.Contains(key.ToString() + ':'))
                    {
                        ActionKeysDict.Add(key, line.Substring(line.LastIndexOf(':') + 1));
                        break;
                    }
                }
            }
        }

        public Dictionary<Keyboard.Key, string> ActionKeysDict = new Dictionary<Keyboard.Key, string>();
    }


    public static class StringToDirection
    {
        static StringToDirection()
        {
            Direction.DirectionFlag[] AllDirections
            = (Direction.DirectionFlag[]) Enum.GetValues(typeof (Direction.DirectionFlag));

            foreach (Direction.DirectionFlag flag in AllDirections)
            {
                ActionsDict.Add(flag.ToString(), flag);
            }
        }

        public static Dictionary<string, Direction.DirectionFlag> ActionsDict = new Dictionary<string, Direction.DirectionFlag>();
    }

    /// <summary>
    /// All Bindins in Bindings.cfg
    /// </summary>
    public class AllBindings
    {
        
        


        public const string PathToFile = @".\Bindings.cfg";

        public static string[] Bindings = File.ReadAllLines(PathToFile);
    }

    
}