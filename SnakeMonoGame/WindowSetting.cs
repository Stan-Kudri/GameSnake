using Core.Components;
using Microsoft.Xna.Framework;

namespace SnakeMonoGame
{
    public class WindowSetting
    {
        private const int TextureFactor = 1;
        private const int DisplayScoreFactor = 3;

        private readonly GraphicsDeviceManager _graphics;
        private readonly BorderSize _size;
        private readonly TextureHolder _textureHolder;

        public WindowSetting(GraphicsDeviceManager graphics, BorderSize size, TextureHolder textureHolder)
        {
            _graphics = graphics;
            _size = size;
            _textureHolder = textureHolder;
        }

        public void Apply()
        {
            // TODO: use this.Content to load your game content here
            var widthWindowGame = (_size.Width + TextureFactor) * _textureHolder.BoardTexture.Width;
            var heightWindowGame = (_size.Height + TextureFactor + DisplayScoreFactor) * _textureHolder.BoardTexture.Height;
            _graphics.PreferredBackBufferWidth = widthWindowGame;
            _graphics.PreferredBackBufferHeight = heightWindowGame;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
        }
    }
}
