using System;
using Core.Components;

namespace SnakeMonoGame
{
    public class GameFacade
    {
        private readonly UserInput _userInput;
        private readonly Speed _speedMono;
        private readonly Score _scoreMono;
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
            _speedMono = speedMono;
            _scoreMono = score;
            _gameMap = gameMap;
            _gameOver = gameOver;

            _userInput.OnChangedDirection += _gameMap.ChangeSnakeDirection;
            _gameMap.OnEatScore += _scoreMono.Increase;
            _scoreMono.OnUpIntervalScore += _speedMono.Increase;
        }

        public void Update(TimeSpan elapsedGameTime)
        {
            if (_gameMap.IsGameOver() || !_speedMono.Update(elapsedGameTime))
            {
                return;
            }

            _gameMap.Move();
        }

        public void Draw()
        {
            _userInput.Update();

            if (_gameMap.IsGameOver())
            {
                _gameOver.Draw();
            }
            else
            {
                _gameMap.Draw();
            }

            _scoreMono.Draw();
        }
    }
}
