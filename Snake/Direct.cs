using GameSnake.Enum;

namespace GameSnake {
    internal class Direct {
        private Directions _currentDirection;

        public Direct(Directions direction) => _currentDirection = direction;

        public Directions Value => _currentDirection;


        public bool ChangeDirection(Directions direction) {
            switch (direction) {
                case Directions.Up:
                case Directions.Down:
                    if (_currentDirection != Directions.Up && _currentDirection != Directions.Down) {
                        _currentDirection = direction;
                        return true;
                    }
                    return false;
                case Directions.Right:
                case Directions.Left:
                    if (_currentDirection != Directions.Right && _currentDirection != Directions.Left) {
                        _currentDirection = direction;
                        return true;
                    }
                    return false;
            }
            return false;
        }
    }
}
