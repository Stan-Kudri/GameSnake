using Core.Components;
using Core.Components.GameMaps;
using GameSnake.ComponentsGame;
using GameSnake.ComponentsGame.GameMaps;
using GameSnake.ComponentsGame.ItemGameMap;
using GameSnake.Extension;

namespace GameSnake
{
    public class Game
    {
        private readonly GameMap _gameMap;
        private readonly IUserInput _userInput;
        private readonly Score _score;
        private readonly Speed _speed;

        public Game(int width, int height, int snakeLength = 5)
        {
            if (snakeLength <= 0)
            {
                throw new ArgumentException("Length snake more zero.", nameof(snakeLength));
            }

            if (width < 1 || height < 1)
            {
                throw new ArgumentException("Invalid board size.");
            }

            _userInput = new UserInput();
            _score = new ScoreConsole(height);
            _speed = new SpeedConsole();

            var border = new BorderConsole(width, height);
            var snake = border.Create(snakeLength);

            _gameMap = new GameMapConsole(border, snake);
            _userInput.OnChangedDirection += _gameMap.ChangeSnakeDirection;
            _gameMap.OnEatScore += _score.Increase;
            _score.OnUpIntervalScore += _speed.Increase;
        }

        public void Run()
        {
            while (!_gameMap.IsGameOver())
            {
                _gameMap.Clear();

                _userInput.Update();
                _gameMap.Move();

                _gameMap.Draw();
                _score.Draw();

                _speed.Apply();
            }

            _gameMap.Clear();
        }
    }
}
