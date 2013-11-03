using System;
using Artemis;
using SFML.Graphics;
using SFML.Window;
using Subject2Change.Components;



namespace Subject2Change
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }

        class Game
        {
            private EntityWorld _world;

            public void Start()
            {
                GameWindow.Window = new RenderWindow(new VideoMode(1280, 720), "Subject2Change");
                GameWindow.Window.SetFramerateLimit(120);
                GameWindow.Window.SetVisible(true);

                GameWindow.Window.Closed += OnClosed;
                GameWindow.Window.KeyPressed += GameEventHandler.OnKeyPressed;
                GameWindow.Window.Resized += GameEventHandler.OnResized;
                GameWindow.Window.KeyReleased += GameEventHandler.OnKeyReleased;
                
                _world = new EntityWorld(false, true, true);

                //Entity camera = _world.CreateEntityFromTemplate("camera");
                EntityFactory.CreatePlayer(_world);

                Sprite testSprite = SFMLwrap.LoadSprite("test.png", SFMLwrap.DefaultScale);

                
                while (GameWindow.Window.IsOpen())
                {
                    GameWindow.Window.DispatchEvents();
                    GameWindow.Window.Clear(Color.Blue);
                    testSprite.Position = EntityFactory.Player.GetComponent<TransformC>().Position;
                    _world.Update();
                    //SpriteBatch batch = new SpriteBatch(GameWindow.Window);

                    GameWindow.Window.Draw(testSprite);
                    GameWindow.Window.Display();
                }
            }

            static void OnClosed(object sender, EventArgs e)
            {
                GameWindow.Window.Close();
            }
        }
    }

    public static class GameWindow
    {
        public static RenderWindow Window { get; set; }
    }
}