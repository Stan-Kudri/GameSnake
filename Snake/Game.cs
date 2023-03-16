using GameSnake.Components;
using GameSnake.Extension;

namespace GameSnake
{
    public class Game
    {
        private GameMap _gameMap;
        private Direction _directory;
        private Score _score;

        public Game(int weight, int height)
        {
            _directory = new Direction();
            _gameMap = new GameMap(weight, height);
            _score = new Score(height);
            _gameMap.OnEatScore += _score.Increase;
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;
                    var direct = key.ToDirection();
                    if (_directory.ChangeDirection(direct))
                    {
                        _gameMap.ChangeSnakeDirection(_directory);
                    }
                }

                _gameMap.Clear();

                //Game over
                if (_gameMap.GameOver)
                {
                    break;
                }

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
