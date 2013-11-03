using System;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Subject2Change.Components;

namespace Subject2Change.Systems
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    internal class ControllableMovementSystem : EntityComponentProcessingSystem<IsControllable, TransformC, Velocity, Direction, ControllableStates>
    {
        public float TimeScale = 1.0f;

        /// <summary>
        /// Overridden Function.
        /// Is automatically called by Artemis via EntityWorld.Update();
        /// Does all the thinking for moving anything in our Game World.
        /// </summary>
        /// <param name="entity">An Artemis entity.</param>
        /// <param name="isControllable">This entity is controllable.</param>
        /// <param name="transform">Our Transform component.</param>
        /// <param name="velocity">Our Velocity Component.</param>
        /// <param name="direction">Our direction component. </param>
        /// <param name="controllableStates">Our State Component for Controllable entites.</param>
        public override void Process(Entity entity, 
                                     IsControllable isControllable,
                                     TransformC transform,
                                     Velocity velocity,
                                     Direction direction,
                                     ControllableStates controllableStates)
        {
            if (velocity == null || transform == null || direction == null|| controllableStates == null) return;
            
            switch (controllableStates.ActiveAction)
            {
                case ControllableStates.Action.Idle:
                    velocity.Speed -= velocity.Acceleration;
                    break;

                case ControllableStates.Action.Moving:
                    velocity.Speed += velocity.Acceleration;
                    break;
            }

            float ms = TimeSpan.FromTicks(EntityWorld.Delta).Milliseconds;
            ms *= TimeScale;
            /*
            #region TOBEREMOVED2
            transform.X += (float) (Math.Cos(velocity.AngleAsRadians)*velocity.Speed*ms);
            transform.Y += (float) (Math.Sin(velocity.AngleAsRadians)*velocity.Speed*ms);
            #endregion
             */
            if (direction.HasFlag(Direction.DirectionFlag.Up)) transform.Y += velocity.Speed * ms;
            if (direction.HasFlag(Direction.DirectionFlag.Down)) transform.Y -= +velocity.Speed*ms;
            
            if (direction.HasFlag(Direction.DirectionFlag.Left)) transform.X += velocity.Speed*ms;
            if (direction.HasFlag(Direction.DirectionFlag.Right)) transform.X -= velocity.Speed * ms;

            if (velocity.Speed > velocity.MaxSpeed) velocity.Speed = velocity.MaxSpeed;
            else if (velocity.Speed < 0.0f) velocity.Speed = 0.0f;
        }
    }
}
#region System without extending
/*
    //Testing System without extending

    [Artemis.Attributes.ArtemisEntitySystem(ExecutionType = ExecutionType.Synchronous, GameLoopType = GameLoopType.Update, Layer = 1)]
    public class MovementSystem : EntityProcessingSystem
    {

        public MovementSystem() : base(Aspect.All(typeof(TransformComponent), typeof(VelocityComponent))) { }

        public override void Process(Entity e)
    {
            VelocityComponent velocity = e.GetComponent<VelocityComponent>();
            float v = velocity.Velocity;

            TransformComponent transform = e.GetComponent<TransformComponent>();

            float r = velocity.AngleAsRadians;

            float xn = transform.X + ((float)Math.Cos(r) * v * Program.World.Delta);
            float yn = transform.Y + ((float)Math.Sin(r) * v * Program.World.Delta);

            transform.Position = new Vector2f(xn, yn);
        }
    }
}* */
#endregion