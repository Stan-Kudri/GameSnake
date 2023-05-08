using Core.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSnake.ComponentsGame
{
    public class ScoreMono : Score
    {
        private readonly Vector2 _textPosition;
        private readonly Color _color = Color.Black;
        private readonly SpriteFont _spriteFont;
        private readonly SpriteBatch _spriteBatch;

        public ScoreMono(int height, SpriteFont spriteFont, SpriteBatch spriteBatch, Texture2D texture2DBoard, int points = 0)
            : base(height, points)
        {
            _startHeightDisplay *= texture2DBoard.Height;
            _spriteBatch = spriteBatch;
            _spriteFont = spriteFont;
            _textPosition = new Vector2(StartWidthDisplay, _startHeightDisplay);
        }

        public override void Draw()
        {
            var scoreLine = $"Score : {Points}";
            _spriteBatch.DrawString(_spriteFont, $"{scoreLine}", _textPosition, _color);
        }
    }
}
