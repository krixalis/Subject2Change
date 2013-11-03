using System;
using Artemis.Interface;

namespace Subject2Change.Components
{
    class ControllableStates : IComponent
    {
        public enum Action
        {
            Idle,
            Moving,
            Jumping,
            Crouching,
            Lying,

            Attacking,
            Defending,

            ActionCount //Always keep last, duh.
        };

        public ControllableStates() : this(Action.Idle) { }
        public ControllableStates(Action state)
        {
            ActiveAction = state;
        }
        private static Action _activeAction;
        public Action ActiveAction { get; set; }
    }
}
