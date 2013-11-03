using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace Subject2Change
{
    class SpriteBatch
    {
        private Vertex[] _vertices = new Vertex[1024 * 4];
        private uint _count;
        private RenderStates _states;
        readonly RenderTarget _rt;

        public SpriteBatch(RenderTarget rt)
        {
            _states = RenderStates.Default;
            _rt = rt;
        }

        public void Display(RenderStates states)
        {
            if (_count == 0) return;
            _rt.Draw(_vertices, 0, _count * 4, PrimitiveType.Quads, states);
        }
        public void Display(Texture texture)
        {
            _states = RenderStates.Default;
            _states.Texture = texture;
            Display(_states);
        }

        public void Flush()
        {
            _count = 0;
        }

        public void Draw(IEnumerable<Sprite> sprites)
        {
            foreach (var s in sprites)
                Draw(s);
        }

        public void Draw(Sprite sprite)
        {
            Draw(sprite.Position, sprite.TextureRect, sprite.Color, sprite.Scale, sprite.Origin, sprite.Rotation);
        }

        public void Draw(Vector2f position, IntRect rec, Color color, Vector2f scale, Vector2f origin, float rotation = 0)
        {
            if (_count >= (_vertices.Length / 4))
                Array.Resize(ref _vertices, _vertices.Length * 2);

            rotation = rotation * (float)Math.PI / 180;
            var sin = (float)Math.Sin(rotation);
            var cos = (float)Math.Cos(rotation);

            origin.X *= scale.X;
            origin.Y *= scale.Y;
            scale.X *= rec.Width;
            scale.Y *= rec.Height;

            Vertex v = new Vertex {Color = color};

            float pX = -origin.X;
            float pY = -origin.Y;

            v.Position.X = pX * cos - pY * sin + position.X;
            v.Position.Y = pX * sin + pY * cos + position.Y;
            v.TexCoords.X = rec.Left;
            v.TexCoords.Y = rec.Top;
            _vertices[_count * 4 + 0] = v;

            pX += scale.X;
            v.Position.X = pX * cos - pY * sin + position.X;
            v.Position.Y = pX * sin + pY * cos + position.Y;
            v.TexCoords.X += rec.Width;
            _vertices[_count * 4 + 1] = v;

            pY += scale.Y;
            v.Position.X = pX * cos - pY * sin + position.X;
            v.Position.Y = pX * sin + pY * cos + position.Y;
            v.TexCoords.Y += rec.Height;
            _vertices[_count * 4 + 2] = v;

            pX -= scale.X;
            v.Position.X = pX * cos - pY * sin + position.X;
            v.Position.Y = pX * sin + pY * cos + position.Y;
            v.TexCoords.X -= rec.Width;
            _vertices[_count * 4 + 3] = v;

            _count++;
        }
    }
}