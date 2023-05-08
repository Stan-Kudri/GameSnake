using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameSnake.ComponentsGame.ItemGameMap;

namespace MonoGameSnake.ComponentsGame
{
    public class GameOver
    {
        private const int DividerLengthHalf = 2;

        private readonly BorderMono _borderMono;
        private readonly Color _color = Color.Azure;
        private readonly SpriteBatch _spriteBatch;
        private readonly Texture2D _texture2D;
        private readonly Vector2 _position;

        public GameOver(BorderMono borderMono, SpriteBatch spriteBatch, Texture2D texture2D)
        {
            _borderMono = borderMono;
            _texture2D = texture2D;
            _position = new Vector2(
                _borderMono.Width * _borderMono.Texture2D.Width / DividerLengthHalf - _texture2D.Width / DividerLengthHalf,
                _borderMono.Height * _borderMono.Texture2D.Height / DividerLengthHalf - _texture2D.Height / DividerLengthHalf);
            _spriteBatch = spriteBatch;
        }

        public void Draw()
        {
            _borderMono.Draw();
            _spriteBatch.Draw(_texture2D, _position, _color);
        }
    }
}
