using System;
using Artemis.Interface;

namespace Subject2Change.Components
{
    public class Velocity : IComponent
    {
        public Velocity() : this(0.0f, 0.0f, 0.5f, 2.0f){}

        public Velocity(float velocity) : this(velocity, 0.0f, 0.5f, 2.0f) { }

        public Velocity(float velocity, float angle) : this(velocity, angle, 0.5f, 2.0f) { }

        public Velocity(float velocity, float angle, float acceleration, float maxspeed)
        {
            Speed = velocity;
            Angle = angle;
            Acceleration = acceleration;
            MaxSpeed = maxspeed;
        }

        /// <summary>
        /// Sets and Gets the Entity's Angle.
        /// </summary>
        public float Angle { get; set; }

        /// <summary>
        /// Sets and Gets the Entity's Acceleration
        /// </summary>
        public float Acceleration { get; set; }

        /// <summary>
        /// Sets and Gets the Entity's Speed.
        /// </summary>
        public float Speed { get; set; } //Called Speed because of class name conflict.

        /// <summary>
        /// Sets and Gets the Entity's maximum Speed value.
        /// </summary>
        public float MaxSpeed { get; set; }

        /// <summary>
        /// Returns the Entity's Angle in Radians.
        /// </summary>
        public float AngleAsRadians
        {
            get { return (float)(Angle * Math.PI / 180.0f); }
        }

        /// <summary>
        /// Adds an angle to the Entity's current Angle.
        /// </summary>
        /// <param name="angle"></param>
        public void AddAngle(float angle)
        {
            Angle = (Angle + angle)%360;
        }
    }
}