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

        public Game(int width, int height, TypeSnake type)
        {
            _userInput = new UserInput();
            _score = new Score(height);

            var border = new Border(width, height);
            var snake = type.CreateSnake(border);

            _gameMap = new GameMap(border, snake);
            _userInput.OnChangedDirection += _gameMap.ChangeSnakeDirection;
            _gameMap.OnEatScore += _score.Increase;
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

                Thread.Sleep(100);
            }

            _gameMap.Clear();
        }
    }
}
