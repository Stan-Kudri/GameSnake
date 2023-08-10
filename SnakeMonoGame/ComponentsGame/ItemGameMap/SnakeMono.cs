using Core.Components.GameMapItems;
using GameSnake.Enum;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSnake.ComponentsGame.ItemGameMap
{
    public class SnakeMono : Snake
    {
        private const int DividerLengthHalf = 2;

        private readonly Color _color = Color.Red;
        private readonly SpriteBatch _spriteBatch;
        private readonly Texture2D _texture2D;

        public SnakeMono(BorderMono border, SpriteBatch spriteBatch, Texture2D texture2D, int length = StartLength, Directions directions = StartDirection)
            : this(
                  (border.Width / DividerLengthHalf) - length,
                  border.Height / DividerLengthHalf,
                  border,
                  spriteBatch,
                  texture2D,
                  length,
                  directions)
        {
        }

        public SnakeMono(int x, int y, Border border, SpriteBatch spriteBatch, Texture2D texture2D, int length = StartLength, Directions directions = StartDirection)
            : base(x, y, border, length, directions)
        {
            _spriteBatch = spriteBatch;
            _texture2D = texture2D;
        }

        public override void Draw()
        {
            Body.ForEach(x => _spriteBatch.Draw(
                _texture2D,
                new Vector2(x.X * _texture2D.Width, x.Y * _texture2D.Height),
                _color));
        }
    }
}
