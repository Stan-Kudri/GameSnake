using GameSnake.Components;

namespace GameSnake
{
    public class Game
    {
        private GameMap _gameMap;
        private UserInput _userInput;
        private Score _score;

        public Game(int weight, int height)
        {
            _userInput = new UserInput();
            _gameMap = new GameMap(weight, height);
            _score = new Score(height);
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
