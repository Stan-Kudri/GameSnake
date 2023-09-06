using Core.Components;
using Microsoft.Xna.Framework;

namespace SnakeMonoGame.ComponentsGame
{
    public class WindowGameSetting
    {
        private const int TextureFactor = 1;
        private const int DisplayScoreFactor = 3;

        private readonly int _widthWindow;
        private readonly int _heightWindow;

        public WindowGameSetting(TextureHolder textureHolder, BorderSize borderSize)
        {
            _widthWindow = (borderSize.Width + TextureFactor) * textureHolder.BoardTexture.Width;
            _heightWindow = (borderSize.Height + TextureFactor + DisplayScoreFactor) * textureHolder.BoardTexture.Height;
        }

        public void Apply(GraphicsDeviceManager deviceManager)
        {
            deviceManager.PreferredBackBufferWidth = _widthWindow;
            deviceManager.PreferredBackBufferHeight = _heightWindow;
            deviceManager.IsFullScreen = false;
            deviceManager.ApplyChanges();
        }
    }
}
