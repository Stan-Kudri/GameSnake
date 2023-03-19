using GameSnake.Components;
using GameSnake.ComponentsGame;

namespace GameSnake
{
    public class Game
    {
        private GameMap _gameMap;
        private UserInput _userInput;
        private Score _score;
        private Speed _speed;

        public Game(int weight, int height)
        {
            _userInput = new UserInput();
            _gameMap = new GameMap(weight, height);
            _score = new Score(height);
            _speed = new Speed();
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

                Thread.Sleep(_speed.Value);
            }

            _gameMap.Clear();
        }
    }
}
