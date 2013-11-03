using Artemis;
using Subject2Change.Components;

namespace Subject2Change
{
    static class EntityFactory
    {
        /// <summary>
        /// The Player of our Game.
        /// Should not be accessed before using CreatePlayer(EntityWorld).
        /// </summary>
        public static Entity Player { get; set; }

        /// <summary>
        /// Creates our Player.
        /// </summary>
        /// <param name="world">The Game's EntityWorld.</param>
        /// <returns>The Player that was just created.</returns>
        public static Entity CreatePlayer(EntityWorld world)
        {
            Player = world.CreateEntityFromTemplate("agent");
            return Player;
        }

        public static Entity Mouse { get; set; }
        
        public static Entity CreateMouse(EntityWorld world)
        {
            Mouse = world.CreateEntity();
            Mouse.AddComponent(new Position());
            return Mouse;
        }
    }
}
