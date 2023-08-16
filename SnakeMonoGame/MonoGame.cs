using System;
using Core;
using Core.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnakeMonoGame
{
    public class MonoGame : Game
    {
        private const int TextureFactor = 1;
        private const int DisplayScoreFactor = 3;

        private readonly IServiceProvider _serviceProvider;
        private readonly GraphicsDeviceManager _deviceManager;
        private SpriteBatch _spriteBatch;

        private GameFacade _gameFacade;
        private BorderSize _borderSize;
        private TextureHolder _textureHolder;

        public MonoGame(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _deviceManager = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = _serviceProvider.GetRequiredService<SpriteBatch>();
            _gameFacade = _serviceProvider.GetRequiredService<GameFacade>();
            _borderSize = _serviceProvider.GetRequiredService<BorderSize>();
            _textureHolder = _serviceProvider.GetRequiredService<TextureHolder>();

            // TODO: use this.Content to load your game content here
            var widthWindowGame = (_borderSize.Width + TextureFactor) * _textureHolder.BoardTexture.Width;
            var heightWindowGame = (_borderSize.Height + TextureFactor + DisplayScoreFactor) * _textureHolder.BoardTexture.Height;
            _deviceManager.PreferredBackBufferWidth = widthWindowGame;
            _deviceManager.PreferredBackBufferHeight = heightWindowGame;
            _deviceManager.IsFullScreen = false;
            _deviceManager.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            if (IsPressedExit())
            {
                Exit();
            }

            _gameFacade.Update(gameTime.ElapsedGameTime);

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SeaShell);

            _spriteBatch.Begin();
            _gameFacade.Draw();
            _spriteBatch.End();

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }

        private static bool IsPressedExit()
        {
            var gamePadState = GamePad.GetState(PlayerIndex.One).Buttons.Back;
            if (gamePadState == ButtonState.Pressed)
            {
                return true;
            }

            var keyBoardState = Keyboard.GetState();
            return keyBoardState.IsKeyDown(Keys.Escape);
        }
    }
}
