using Core.Components.GameMapItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSnake.ComponentsGame.ItemGameMap
{
    public class BorderMono : Border
    {
        private readonly Color _color = Color.Salmon;
        private readonly SpriteBatch _spriteBatch;
        private readonly Texture2D _texture2D;

        public BorderMono(int width, int height, SpriteBatch spriteBatch, Texture2D texture2D)
            : base(width, height)
        {
            _spriteBatch = spriteBatch;
            _texture2D = texture2D;
        }

        public Texture2D Texture2D => _texture2D;

        public override void Draw()
        {
            Borders.ForEach(x => _spriteBatch.Draw(
                _texture2D,
                new Vector2(x.X * _texture2D.Width, x.Y * _texture2D.Height),
                _color));
        }
    }
}
