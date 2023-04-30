using Core.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSnake.ComponentsGame
{
    public class ScoreMono : Score
    {
        private Vector2 _textPosition;
        private Color _color = Color.Black;
        private SpriteFont _spriteFont;
        private SpriteBatch _spriteBatch;

        public ScoreMono(int height, int points = 0)
            : base(height, points)
        {
        }

        public void UpdateHeight(Texture2D texture2DBoard) => _startHeightDisplay *= texture2DBoard.Height;

        public override void Draw()
        {
            var scoreLine = $"Score : {Points}";
            _spriteBatch.DrawString(_spriteFont, $"{scoreLine}", _textPosition, _color);
        }

        public void Initialize(SpriteFont spriteFont, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _spriteFont = spriteFont;
            _textPosition = new Vector2(StartWidthDisplay, _startHeightDisplay);
        }
    }
}
