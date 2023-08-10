using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameSnake.ComponentsGame;
using MonoGameSnake.ComponentsGame.ItemGameMap;

namespace SnakeMonoGame
{
    public class MonoGame : Game
    {
        private const int TextureFactor = 1;
        private const int DisplayScoreFactor = 3;

        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly int _height;
        private readonly int _width;

        private SnakeMono _snake;
        private BorderMono _border;

        private GameOverMono _gameOver;
        private ScoreMono _score;
        private GameMapMono _gameMap;
        private SpeedMono _speed;
        private UserInputMono _userInput;

        public MonoGame(int height, int width)
        {
            if (width < 1 || height < 1)
            {
                throw new ArgumentException("Invalid game size.");
            }

            _height = height;
            _width = width;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var boardTexture2D = Content.Load<Texture2D>("BorderElement");
            var snakeTexture2D = Content.Load<Texture2D>("SnakeElement");
            var foodTexture2D = Content.Load<Texture2D>("Food");
            var gameOverTexture2D = Content.Load<Texture2D>("GameOver");
            var font = Content.Load<SpriteFont>("Font");

            var service = new ServiceCollection()
                .AddSingleton(new BorderMono(_width, _height, _spriteBatch, boardTexture2D))
                .AddScoped(x => new SnakeMono(
                    x.GetRequiredService<BorderMono>(), _spriteBatch, snakeTexture2D))
                .AddScoped(x => new GameMapMono(
                    x.GetRequiredService<BorderMono>(), x.GetRequiredService<SnakeMono>(), _spriteBatch, foodTexture2D))
                .AddScoped<UserInputMono>()
                .AddScoped<SpeedMono>()
                .AddSingleton(x => new ScoreMono(_height, font, _spriteBatch, boardTexture2D))
                .AddSingleton(x => new GameOverMono(x.GetRequiredService<BorderMono>(), _spriteBatch, gameOverTexture2D));

            using var container = service.BuildServiceProvider();
            using var serviceScope = container.CreateScope();

            _border = serviceScope.ServiceProvider.GetRequiredService<BorderMono>();
            _snake = serviceScope.ServiceProvider.GetRequiredService<SnakeMono>();
            _gameMap = serviceScope.ServiceProvider.GetRequiredService<GameMapMono>();

            _userInput = serviceScope.ServiceProvider.GetRequiredService<UserInputMono>();
            _speed = serviceScope.ServiceProvider.GetRequiredService<SpeedMono>();
            _score = serviceScope.ServiceProvider.GetRequiredService<ScoreMono>();
            _gameOver = serviceScope.ServiceProvider.GetRequiredService<GameOverMono>();

            _userInput.OnChangedDirection += _gameMap.ChangeSnakeDirection;
            _gameMap.OnEatScore += _score.Increase;
            _score.OnUpIntervalScore += _speed.Increase;
            _speed.OnTimeMovie += _gameMap.Move;

            // TODO: use this.Content to load your game content here
            var widthWindowGame = (_border.Width + TextureFactor) * boardTexture2D.Width;
            var heightWindowGame = (_border.Height + TextureFactor + DisplayScoreFactor) * boardTexture2D.Height;
            _graphics.PreferredBackBufferWidth = widthWindowGame;
            _graphics.PreferredBackBufferHeight = heightWindowGame;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            if (IsPressedExit())
            {
                Exit();
            }

            if (!_gameMap.IsGameOver())
            {
                _speed.Update(gameTime);
            }

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SeaShell);
            _spriteBatch.Begin();
            _userInput.Update();

            if (_gameMap.IsGameOver())
            {
                _gameOver.Draw();
            }
            else
            {
                _gameMap.Draw();
            }

            _score.Draw();
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
