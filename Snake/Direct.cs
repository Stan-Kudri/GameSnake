using GameSnake.Enum;

namespace GameSnake {
    internal class Direct {
        private Directions _directory;

        public Direct(Directions direction) => _directory = direction;

        public Directions Value => _directory;


        public bool NewDirection(ConsoleKeyInfo info) {
            switch (info.Key) {
                case ConsoleKey.UpArrow:
                    if (_directory != Directions.Up && _directory != Directions.Down) {
                        _directory = Directions.Up;
                        return true;
                    }
                    return false;
                case ConsoleKey.DownArrow:
                    if (_directory != Directions.Up && _directory != Directions.Down) {
                        _directory = Directions.Down;
                        return true;
                    }
                    return false;
                case ConsoleKey.RightArrow:
                    if (_directory != Directions.Right && _directory != Directions.Left) {
                        _directory = Directions.Right;
                        return true;
                    }
                    return false;
                case ConsoleKey.LeftArrow:
                    if (_directory != Directions.Right && _directory != Directions.Left) {
                        _directory = Directions.Left;
                        return true;
                    }
                    return false;
            }
            return false;
        }
    }
}
