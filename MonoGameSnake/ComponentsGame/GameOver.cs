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

        private SpriteBatch _spriteBatch;
        private Vector2 _position;
        private Texture2D _texture2D;

        public GameOver(BorderMono borderMono) => _borderMono = borderMono;

        public void LoadContent(Texture2D texture2D)
        {
            _texture2D = texture2D;
            _position = new Vector2(
                _borderMono.Width * _borderMono.Texture2D.Width / DividerLengthHalf - _texture2D.Width / DividerLengthHalf,
                _borderMono.Height * _borderMono.Texture2D.Height / DividerLengthHalf - _texture2D.Height / DividerLengthHalf);

        }

        public void Initialize(SpriteBatch spriteBatch) => _spriteBatch = spriteBatch;

        public void Draw()
        {
            _borderMono.Draw();
            _spriteBatch.Draw(_texture2D, _position, _color);
        }
    }
}
