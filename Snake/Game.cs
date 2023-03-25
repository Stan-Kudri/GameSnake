using GameSnake.Components;
using GameSnake.Components.ItemGameMap;
using GameSnake.ComponentsGame;
using GameSnake.ComponentsGame.ItemGameMap.SnakeType;

namespace GameSnake
{
    public class Game
    {
        private GameMap _gameMap;
        private UserInput _userInput;
        private Score _score;

        public Game(int width, int height, int snakeLength = 5)
        {
            _userInput = new UserInput();
            _score = new Score(height);

            var border = new Border(width, height);
            var snake = new Snake((border.Width / 2) - snakeLength, border.Height / 2, border, snakeLength);

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
