using System;
using Core.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SnakeMonoGame;

namespace MonoGameSnake.ComponentsGame
{
    public class ScoreMono : Score
    {
        private const int StartWidthDisplay = 0;

        private readonly Vector2 _textPosition;
        private readonly Color _color = Color.Black;
        private readonly SpriteFont _spriteFont;
        private readonly IServiceProvider _serviceProvider;

        public ScoreMono(BorderSize size, IServiceProvider serviceProvider, TextureHolder textureHolder)
            : base(size.Height)
        {
            _startHeightDisplay *= textureHolder.BoardTexture.Height;
            _serviceProvider = serviceProvider;
            _spriteFont = textureHolder.Font;
            _textPosition = new Vector2(StartWidthDisplay, _startHeightDisplay);
        }

        public override void Draw()
        {
            var scoreLine = $"Score : {Points}";
            _serviceProvider.GetRequiredService<SpriteBatch>().DrawString(_spriteFont, $"{scoreLine}", _textPosition, _color);
        }
    }
}
