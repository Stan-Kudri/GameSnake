using Core.Components;
using GameSnake.ComponentsGame;

namespace GameSnake
{
    public class ConsoleGame
    {
        private readonly GameMapConsole _gameMap;
        private readonly UserInput _userInput;
        private readonly Score _score;
        private readonly SpeedConsole _speed;
        private readonly GameOver _gameOver;

        public ConsoleGame(
            UserInput userInput,
            Score score,
            SpeedConsole speed,
            GameMapConsole gameMap,
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
