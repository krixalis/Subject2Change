using SFML.Graphics;
using SFML.Window;

namespace Subject2Change
{
    class SFMLwrap
    {
        public static Vector2f DefaultScale = new Vector2f(8, 8);

        public static Sprite LoadSprite(string fileName)
        {
            Texture texture = new Texture(fileName);
            Sprite sprite = new Sprite(texture);
            return sprite;
        }

        public static Sprite LoadSprite(string fileName, Vector2f scale)
        {
            Image image = new Image(fileName);
            Texture texture = new Texture(image);
            Sprite sprite = new Sprite(texture) { Scale = scale };
            return sprite;
        }

        public static Sprite LoadSprite(string fileName, Vector2f scale, bool flipH, bool flipV)
        {
            Image image = new Image(fileName);
            if (flipH) image.FlipHorizontally();
            else if (flipV) image.FlipVertically();
            Texture texture = new Texture(image);
            Sprite sprite = new Sprite(texture) { Scale = scale };
            return sprite;
        }
    }
}