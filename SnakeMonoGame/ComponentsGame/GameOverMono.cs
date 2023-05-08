using Core.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameSnake.ComponentsGame.ItemGameMap;

namespace MonoGameSnake.ComponentsGame
{
    public class GameOverMono : GameOver
    {
        private const int DividerLengthHalf = 2;

        private readonly Color _color = Color.Azure;
        private readonly SpriteBatch _spriteBatch;
        private readonly Texture2D _texture2D;
        private readonly Vector2 _position;

        public GameOverMono(BorderMono borderMono, SpriteBatch spriteBatch, Texture2D texture2D)
            : base(borderMono)
        {
            _texture2D = texture2D;
            _position = new Vector2(
                borderMono.Width * borderMono.Texture2D.Width / DividerLengthHalf - _texture2D.Width / DividerLengthHalf,
                borderMono.Height * borderMono.Texture2D.Height / DividerLengthHalf - _texture2D.Height / DividerLengthHalf);
            _spriteBatch = spriteBatch;
        }

        public override void Draw()
        {
            _border.Draw();
            _spriteBatch.Draw(_texture2D, _position, _color);
        }
    }
}
