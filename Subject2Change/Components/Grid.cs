using Artemis.Interface;
using SFML.Window;

namespace Subject2Change.Components
{
    public class Grid : IComponent
    {
        public Grid() : this(new Vector2i(512, 512), new Vector2i(64, 32)) { }

        public Grid(Vector2i gridSize, Vector2i cellSize)
        {
            GridSize = gridSize;
            CellSize = cellSize;
        }

        public Vector2i GridSize
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


        public Vector2i CellSize
        {
            get { return new Vector2i(CellX, CellY); }
            set
            {
                CellX = value.X;
                CellY = value.Y;
            }
        }
        private int CellX { get; set; }
        private int CellY { get; set; }
    }
}
