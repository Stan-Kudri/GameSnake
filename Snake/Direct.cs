using GameSnake.Enum;

namespace GameSnake {
    internal class Direct {
        private Directions _currentDirection;

        public Direct(Directions direction) => _currentDirection = direction;

        public Directions Value => _currentDirection;


        public bool ChangeDirection(ConsoleKey key) {
            switch (key) {
                case ConsoleKey.UpArrow:
                    if (_currentDirection != Directions.Up && _currentDirection != Directions.Down) {
                        _currentDirection = Directions.Up;
                        return true;
                    }
                    return false;
                case ConsoleKey.DownArrow:
                    if (_currentDirection != Directions.Up && _currentDirection != Directions.Down) {
                        _currentDirection = Directions.Down;
                        return true;
                    }
                    return false;
                case ConsoleKey.RightArrow:
                    if (_currentDirection != Directions.Right && _currentDirection != Directions.Left) {
                        _currentDirection = Directions.Right;
                        return true;
                    }
                    return false;
                case ConsoleKey.LeftArrow:
                    if (_currentDirection != Directions.Right && _currentDirection != Directions.Left) {
                        _currentDirection = Directions.Left;
                        return true;
                    }
                    return false;
            }
            return false;
        }
    }
}
