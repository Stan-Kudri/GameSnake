using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameSnake.ComponentsGame;
using MonoGameSnake.ComponentsGame.ItemGameMap;
using MonoGameSnake.Extension;

namespace SnakeMonoGame
{
    public class MonoGame : Game
    {
        private const int TextureFactor = 1;
        private const int DisplayScoreFactor = 3;

        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SnakeMono _snake;
        private BorderMono _border;

        private GameOverMono _gameOver;
        private ScoreMono _score;
        private GameMapMono _gameMap;
        private SpeedMono _speed;
        private UserInputMono _userInput;

        public MonoGame()
        {
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

            _border = new BorderMono(20, 20, _spriteBatch, boardTexture2D);
            _snake = _border.Creator(_spriteBatch, snakeTexture2D);
            _gameMap = new GameMapMono(_border, _snake, foodTexture2D, _spriteBatch);

            _userInput = new UserInputMono();
            _speed = new SpeedMono();
            _score = new ScoreMono(_border.Height, font, _spriteBatch, boardTexture2D);
            _gameOver = new GameOverMono(_border, _spriteBatch, gameOverTexture2D);

            _userInput.OnChangedDirection += _gameMap.ChangeSnakeDirection;
            _gameMap.OnEatScore += _score.Increase;
            _score.OnUpIntervalScore += _speed.Increase;
            _speed.OnPressButton += _userInput.Update;
            _speed.OnTimeMovie += _gameMap.Move;

            // TODO: use this.Content to load your game content here
            var widthWindowGame = (_border.Width + TextureFactor) * (boardTexture2D.Width);
            var heightWindowGame = (_border.Height + TextureFactor + DisplayScoreFactor) * (boardTexture2D.Height);
            _graphics.PreferredBackBufferWidth = widthWindowGame;
            _graphics.PreferredBackBufferHeight = heightWindowGame;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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
    }
}
