using GameSnake.Components;

namespace GameSnake
{
    public class Game
    {
        private bool GameOver = false;
        private GameMap _gameMap;
        private UserInput _directory;
        private Score _score;

        public Game(int weight, int height)
        {
            _directory = new UserInput();
            _gameMap = new GameMap(weight, height);
            _score = new Score(height);
            _directory.OnChangedDirection += _gameMap.ChangeSnakeDirection;
            _gameMap.OnEatScore += _score.Increase;
        }

        public void Run()
        {
            while (!GameOver)
            {
                _gameMap.Clear();

                //Game over
                if (_gameMap.GameOver)
                {
                    GameOver = true;
                    break;
                }

                _directory.UseKey();
                _gameMap.Move();

                _gameMap.Draw();
                _score.Draw();

                Thread.Sleep(100);
            }
        }

        public void DrawMap()
        {
            _gameMap.DrawBoarder();
            _gameMap.Draw();
            _score.Draw();
        }
    }
}
