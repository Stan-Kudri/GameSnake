using GameSnake.Components;

namespace GameSnake
{
    public class Game
    {
        private GameMap _gameMap;
        private UserInput _direction;
        private Score _score;

        public Game(int weight, int height)
        {
            _direction = new UserInput();
            _gameMap = new GameMap(weight, height);
            _score = new Score(height);
            _direction.OnChangedDirection += _gameMap.ChangeSnakeDirection;
            _gameMap.OnEatScore += _score.Increase;
        }

        public void Run()
        {
            while (!_gameMap.GameOver)
            {
                _gameMap.Clear();

                _direction.Update();
                _gameMap.Move();

                _gameMap.Draw();
                _score.Draw();

                Thread.Sleep(100);
            }

            _gameMap.Clear();
        }
    }
}
