using Core.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameSnake.ComponentsGame.ItemGameMap;

namespace MonoGameSnake.ComponentsGame
{
    public class GameOverMono : GameOver
    {
        private readonly Color _color = Color.Azure;
        private readonly SpriteBatch _spriteBatch;
        private readonly Texture2D _texture2D;
        private readonly Vector2 _position;

        public GameOverMono(BorderMono borderMono, SpriteBatch spriteBatch, Texture2D texture2D)
            : base(borderMono)
        {
            _texture2D = texture2D;
            _spriteBatch = spriteBatch;
            var centerFieldOfX = (borderMono.Width + 1) * borderMono.Texture2D.Width / 2;
            var centerFieldOfY = (borderMono.Height + 1) * borderMono.Texture2D.Height / 2;
            var centerPicturesGameOverOfX = _texture2D.Width / 2;
            var centerPicturesGameOverOfY = _texture2D.Height / 2;

            var positionOfX = centerFieldOfX - centerPicturesGameOverOfX;
            var positionOfY = centerFieldOfY - centerPicturesGameOverOfY;
            _position = new Vector2(positionOfX, positionOfY);
        }

        public override void Draw()
        {
            _border.Draw();
            _spriteBatch.Draw(_texture2D, _position, _color);
        }
    }
}
