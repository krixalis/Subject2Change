using System;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Subject2Change.Components;

namespace Subject2Change.Systems
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    class Mouse : EntityComponentProcessingSystem<Position>
    {
        public override void Process(Entity entity,
                                     Position position)
        {
            position.ScreenPosition = SFML.Window.Mouse.GetPosition(GameWindow.Window);
            Console.WriteLine(position.ScreenPosition.ToString());
        }
    }
}
