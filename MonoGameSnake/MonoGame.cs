using GameSnake.Enum;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameSnake.ComponentsGame;
using MonoGameSnake.ComponentsGame.ItemGameMap;
using MonoGameSnake.Extension;

namespace MonoGameSnake
{
    public class MonoGame : Game
    {
        private const int CorrectionFactorTexture = 1;
        private const int CorrectionFactorScore = 2;

        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SnakeMono _snake;
        private BorderMono _border;

        private GameOver _gameOver;
        private ScoreMono _score;
        private GameMapMono _gameMap;
        private SpeedMono _speed;
        private UserInput _userInput;

        private KeyboardState _keyboardState, _oldKeyBoard;

        private int _currentTimeMove = 0; // The amount of elapsed time.
        private int _currentTimeButton = 0; // Time from button press.

        public MonoGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _userInput = new UserInput();
            _border = new BorderMono(20, 20);
            _snake = _border.Creator();
            _score = new ScoreMono(_border.Height);
            _speed = new SpeedMono();
            _gameOver = new GameOver(_border);

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
            var font = Content.Load<SpriteFont>("SpriteFont");

            _border.Initialize(_spriteBatch);
            _snake.Initialize(_spriteBatch);
            _gameOver.Initialize(_spriteBatch);

            _score.UpdateHeight(boardTexture2D);
            _score.Initialize(font, _spriteBatch);

            _border.LoadContent(boardTexture2D);
            _snake.LoadContent(snakeTexture2D);
            _gameOver.LoadContent(gameOverTexture2D);

            _gameMap = new GameMapMono(_border, _snake, foodTexture2D, _spriteBatch);

            _userInput.OnChangedDirection += _gameMap.ChangeSnakeDirection;
            _gameMap.OnEatScore += _score.Increase;
            _score.OnUpIntervalScore += _speed.Increase;

            // TODO: use this.Content to load your game content here

            _graphics.PreferredBackBufferWidth = (_border.Width + CorrectionFactorTexture) * (boardTexture2D.Width);
            _graphics.PreferredBackBufferHeight = (_border.Height + CorrectionFactorTexture + CorrectionFactorScore) * (boardTexture2D.Height);
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            _keyboardState = Keyboard.GetState();
            _currentTimeMove += gameTime.ElapsedGameTime.Milliseconds;
            _currentTimeButton += gameTime.ElapsedGameTime.Milliseconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (!_gameMap.IsGameOver())
            {
                if (_currentTimeButton >= _speed.TimePressButton)
                {
                    if (_keyboardState.IsKeyDown(Keys.Up) && _keyboardState != _oldKeyBoard)
                    {
                        _userInput.Update(Directions.Up);
                    }
                    else if (_keyboardState.IsKeyDown(Keys.Down) && _keyboardState != _oldKeyBoard)
                    {
                        _userInput.Update(Directions.Down);
                    }
                    else if (_keyboardState.IsKeyDown(Keys.Left) && _keyboardState != _oldKeyBoard)
                    {
                        _userInput.Update(Directions.Left);
                    }
                    else if (_keyboardState.IsKeyDown(Keys.Right) && _keyboardState != _oldKeyBoard)
                    {
                        _userInput.Update(Directions.Right);
                    }

                    if (_oldKeyBoard != _keyboardState)
                    {
                        _oldKeyBoard = _keyboardState;
                        _currentTimeButton = 0;
                    }
                }

                if (_currentTimeMove >= _speed.TimeMove)
                {
                    _gameMap.Move();
                    _currentTimeMove -= _speed.TimeMove;
                }
            }

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SeaShell);
            _spriteBatch.Begin();

            if (!_gameMap.IsGameOver())
            {
                _gameMap.Draw();
            }
            else
            {
                _gameOver.Draw();
            }

            _score.Draw();
            _spriteBatch.End();

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
