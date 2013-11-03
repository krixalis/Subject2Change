using Artemis.Interface;
using SFML.Window;

namespace Subject2Change.Components
{
    internal class Position : IComponent
    {
        public Position() : this(new Vector2f(0, 0), new Vector2i(0, 0)){}

        public Position(float x, float y)
            : this(new Vector2f(x, y), new Vector2i(0, 0)){}//eventually change
                                                            //to set 0,0 to actual pos
                                                            //derived from given pos
        public Position(int x, int y)
            : this(new Vector2f(0, 0), new Vector2i(x, y)){}//TODO: read above
        
        public Position(Vector2f rPosition, Vector2i gPosition)
        {
            RelativePosition = rPosition;
            GridPosition = gPosition;
        }

        public Vector2f RelativePosition
        {
            get { return new Vector2f(RelX, RelY); }
            set
            {
                RelX = value.X;
                RelY = value.Y;
            }
        }
        private float RelX { get; set; }
        private float RelY { get; set; }

        public Vector2i GridPosition
        {
            get { return new Vector2i(GridX, GridY); }
            set
            {
                GridX = value.X;
                GridY = value.Y;
            }
        }
        private int GridX { get; set; }
        private int GridY { get; set; }

        public Vector2i ScreenPosition
        {
            get { return new Vector2i(ScreenX, ScreenY); }
            set
            {
                ScreenX = value.X;
                ScreenY = value.Y;
            }
        }
        private int ScreenX { get; set; }
        private int ScreenY { get; set; }
    }
}