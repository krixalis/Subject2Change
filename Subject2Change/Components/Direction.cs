using System;
using System.Collections.Generic;
using Artemis.Interface;

namespace Subject2Change.Components
{
    public class Direction : IComponent
    {
        [Flags]
        public enum DirectionFlag
        {
            None = 0,
            Up = 1,
            Down = 2,
            Left = 4,
            Right = 8,
        }

        private static List<DirectionFlag> ActiveFlags = new List<DirectionFlag>();

        //private DirectionFlag[] ActiveFlags { get; set; }

        public bool HasFlag(DirectionFlag flag)
        {
            if (ActiveFlags == null) return false;
            return ActiveFlags.Contains(flag);
        }

        public void SetFlag(DirectionFlag flag)
        {
            if(!ActiveFlags.Contains(flag))
                ActiveFlags.Add(flag);
        }

        public void SetFlags(DirectionFlag flag1, DirectionFlag flag2)
        {
            SetFlag(flag1);
            SetFlag(flag2);
        }

        public void RemoveFlag(DirectionFlag flag)
        {
            ActiveFlags.Remove(flag);
        }

        public void RemoveFlags(DirectionFlag flag1, DirectionFlag flag2)
        {
            RemoveFlag(flag1);
            RemoveFlag(flag2);
        }
    }
}
