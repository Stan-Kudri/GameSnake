using Core.Components;

namespace Core.Games
{
    public class Game
    {
        private readonly GameMap _gameMap;
        private readonly IUserInput _userInput;
        private readonly Score _score;
        private readonly Speed _speed;

        public Game(
            IUserInput userInput,
            Score score,
            Speed speed,
            GameMap gameMap)
        {
            _userInput = userInput;
            _score = score;
            _speed = speed;
            _gameMap = gameMap;

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
