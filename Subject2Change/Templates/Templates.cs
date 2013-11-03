using Artemis;
using Artemis.Attributes;
using Artemis.Interface;
using Subject2Change.Components;

namespace Subject2Change.Templates
{
    [ArtemisEntityTemplate("agent")]
    public class AgentTemplate : IEntityTemplate
    {
        public Entity BuildEntity(Entity e, EntityWorld world, params object[] args)
        {
            e.AddComponent(new Direction());
            e.AddComponent(new IsControllable());
            e.AddComponent(new ControllableStates());
            e.AddComponent(new Position());
            e.AddComponent(new Health());
            e.AddComponent(new Velocity());
            e.AddComponent(new TransformC());

            e.Refresh();

            return e;
        }
    }
    [ArtemisEntityTemplate("camera")]
    public class CameraTemplate : IEntityTemplate
    {
        public Entity BuildEntity(Entity e, EntityWorld world, params object[] args)
        {
            e.AddComponent(new Position());
            
            e.Refresh();

            return e;
        }
    }
}