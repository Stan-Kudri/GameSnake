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
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SnakeMono _snake;
        private BoarderMono _border;

        private ScoreMono _score;
        private GameMapMono _gameMap;
        private SpeedMono _speed;
        private UserInput _userInput;

        public MonoGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 500;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            _userInput = new UserInput();
            _border = new BoarderMono(20, 20);
            _snake = _border.Creator();
            _score = new ScoreMono(_border.Height);
            _speed = new SpeedMono();

            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _border.Initialize(_spriteBatch);
            _snake.Initialize(_spriteBatch);

            var boardTexture2D = Content.Load<Texture2D>("BorderElement");
            var snakeTexture2D = Content.Load<Texture2D>("SnakeElement");
            var foodTexture2D = Content.Load<Texture2D>("Food");
            var font = Content.Load<SpriteFont>("SpriteFont");

            _border.LoadContent(boardTexture2D);
            _snake.LoadContent(snakeTexture2D);
            _score.UpdateHeight(boardTexture2D);
            _score.Initialize(font, _spriteBatch);
            _gameMap = new GameMapMono(_border, _snake, foodTexture2D, _spriteBatch);

            _userInput.OnChangedDirection += _gameMap.ChangeSnakeDirection;
            _gameMap.OnEatScore += _score.Increase;
            _score.OnUpIntervalScore += _speed.Increase;
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                _userInput.Update(Directions.Up);
                _gameMap.Move();
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                _userInput.Update(Directions.Down);
                _gameMap.Move();
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                _userInput.Update(Directions.Left);
                _gameMap.Move();
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                _userInput.Update(Directions.Right);
                _gameMap.Move();
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SeaShell);

            _spriteBatch.Begin();

            _gameMap.Draw();
            _score.Draw();

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
