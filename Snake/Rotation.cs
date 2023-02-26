using GameSnake.Enum;

namespace GameSnake {
    internal class Rotation {
        private Direction _directory;

        public Rotation(Direction direction) => _directory = direction;

        public Direction Value => _directory;


        public bool NewDirection(ConsoleKeyInfo info) {
            switch (info.Key) {
                case ConsoleKey.UpArrow:
                    if (_directory != Direction.Up && _directory != Direction.Down) {
                        _directory = Direction.Up;
                        return true;
                    }
                    return false;
                case ConsoleKey.DownArrow:
                    if (_directory != Direction.Up && _directory != Direction.Down) {
                        _directory = Direction.Down;
                        return true;
                    }
                    return false;
                case ConsoleKey.RightArrow:
                    if (_directory != Direction.Right && _directory != Direction.Left) {
                        _directory = Direction.Right;
                        return true;
                    }
                    return false;
                case ConsoleKey.LeftArrow:
                    if (_directory != Direction.Right && _directory != Direction.Left) {
                        _directory = Direction.Left;
                        return true;
                    }
                    return false;
            }
            return false;
        }
    }
}
