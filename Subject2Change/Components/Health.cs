using System;
using Artemis.Interface;

namespace Subject2Change.Components
{
    public class Health : IComponent
    {
        public Health() : this(0.0f)
        {
        }
        
        public Health(float health)
        {
            CurrentHealth = MaximumHealth = health;
        }

        public bool IsAlive
        {
            get { return CurrentHealth > 0.0f; }
        }

        public double HealthPercentage
        {
            get { return Math.Round(CurrentHealth / MaximumHealth * 100.0f); }
        }

        public void Damage(float damage)
        {
            CurrentHealth -= damage;
        }


        public float CurrentHealth { get; set; }

        public float MaximumHealth { get; private set; }
    }
}
