using Core.Components;

namespace Core
{
    public class GameFacade
    {
        private readonly UserInput _userInput;
        private readonly Speed _speed;
        private readonly Score _score;
        private readonly GameMap _gameMap;
        private readonly GameOver _gameOver;

        public GameFacade(
            UserInput userInput,
            Speed speedMono,
            Score score,
            GameMap gameMap,
            GameOver gameOver)
        {
            _userInput = userInput;
            _speed = speedMono;
            _score = score;
            _gameMap = gameMap;
            _gameOver = gameOver;

            _userInput.OnChangedDirection += _gameMap.ChangeSnakeDirection;
            _gameMap.OnEatScore += _score.Increase;
            _score.OnUpIntervalScore += _speed.Increase;
        }

        public void Update(TimeSpan elapsedGameTime)
        {
            if (_gameMap.IsGameOver())
            {
                return;
            }
            else if (!_speed.Update(elapsedGameTime))
            {
                _userInput.Update();
                return;
            }

            _userInput.Update();
            _gameMap.Move();
        }

        public void Draw()
        {
            if (_gameMap.IsGameOver())
            {
                _gameOver.Draw();
            }
            else
            {
                _gameMap.Draw();
            }

            _score.Draw();
        }
    }
}
