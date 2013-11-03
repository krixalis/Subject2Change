using Artemis.Interface;
using SFML.Window;

namespace Subject2Change.Components
{
    public class TransformC : IComponent
    {
        public TransformC() : this(new Vector2f(0, 0)){}

        public TransformC(float x, float y) : this(new Vector2f(x, y)){}

        public TransformC(Vector2f position)
        {
            Position    = position;
        }

        public Vector2f Position
        {
            get { return new Vector2f(X, Y); }
            set 
            { 
                X = value.X;
                Y = value.Y;
            }
        }

        public float X { get; set; }

        public float Y { get; set; }

        public void Nullify()
        {
            Position = new Vector2f(0.0f, 0.0f);
        }
    }
}
