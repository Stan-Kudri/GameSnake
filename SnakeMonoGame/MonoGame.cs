using System;
using Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SnakeMonoGame.ComponentsGame;

namespace SnakeMonoGame
{
    public class MonoGame : Game
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly GraphicsDeviceManager _deviceManager;
        private SpriteBatch _spriteBatch;

        private GameFacade _gameFacade;
        private WindowGameSetting _windowSetting;

        public MonoGame(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _deviceManager = new GraphicsDeviceManager(this);
        }

        protected override void Initialize() => base.Initialize();

        protected override void LoadContent()
        {
            _spriteBatch = _serviceProvider.GetRequiredService<SpriteBatch>();
            _gameFacade = _serviceProvider.GetRequiredService<GameFacade>();

            // TODO: use this.Content to load your game content here
            _windowSetting = _serviceProvider.GetRequiredService<WindowGameSetting>();
            _windowSetting.Apply(_deviceManager);
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
