using Core.Components;

namespace Core
{
    public class Game
    {
        private readonly GameMap _gameMap;
        private readonly IUserInput _userInput;
        private readonly Score _score;
        private readonly Speed _speed;
        private readonly GameOver _gameOver;

        public Game(
            IUserInput userInput,
            Score score,
            Speed speed,
            GameMap gameMap,
            GameOver gameOver)
        {
            _userInput = userInput;
            _score = score;
            _speed = speed;
            _gameMap = gameMap;
            _gameOver = gameOver;

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
            _gameOver.Draw();
        }
    }
}
