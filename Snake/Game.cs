using GameSnake.Components;
using GameSnake.Components.ItemGameMap;
using GameSnake.ComponentsGame;
using GameSnake.Enum;
using GameSnake.Extension;

namespace GameSnake
{
    public class Game
    {
        private GameMap _gameMap;
        private UserInput _userInput;
        private Score _score;
        private Speed _speed;

        public Game(int width, int height, TypeSnake type)
        {
            _userInput = new UserInput();
            _score = new Score(height);
            _speed = new Speed();

            var border = new Border(width, height);
            var snake = type.CreateTypeSnakeGame(border) ?? throw new ArgumentException("Unknown type of snake.");

            _gameMap = new GameMap(border, snake);
            _userInput.OnChangedDirection += _gameMap.ChangeSnakeDirection;
            _gameMap.OnEatScore += _score.Increase;
            _score.OnUpIntervalScore += _speed.Increase;
        }

        public void Run()
        {
            while (!_gameMap.GameOver)
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
