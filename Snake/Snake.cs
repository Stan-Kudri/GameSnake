using GameSnake.Enum;

namespace GameSnake {
    public class Snake {
        public const char SymbolSnake = 'o';

        private int _heightField = 20;
        private int _widthField = 40;

        private Point _head;
        private Point _tail;
        private int _length = 1;
        private Direction _directory;

        public Snake(int x, int y) : this(x, y, 1) { }

        public Snake(int x, int y, int length) {
            _head = new Point(x, y, SymbolSnake);
            _head.Draw();
        }

        public Direction Direction {
            get => _directory;
            set => _directory = value;
        }

        public void Move() {
            _head.Clear();
            _head = GetNextPoint();
            _head.Draw();
            Thread.Sleep(100);
        }

        private Point GetNextPoint() {
            Point point = _head.Get;

            switch (_directory) {
                case Direction.Up:
                    --point.Y;
                    if (point.Y == 0)
                        point.Y = _heightField;
                    break;
                case Direction.Down:
                    ++point.Y;
                    if (point.Y == _heightField)
                        point.Y = 0;
                    break;
                case Direction.Right:
                    ++point.X;
                    if (point.X == _widthField)
                        point.X = 0;
                    break;
                case Direction.Left:
                    --point.X;
                    if (point.X == 0)
                        point.X = _widthField;
                    break;
            }

            return point.Get;
        }
    }
}
