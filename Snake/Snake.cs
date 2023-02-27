using GameSnake.Enum;

namespace GameSnake {
    public class Snake {
        public const char SymbolSnake = 'o';

        private int _heightField = 20;
        private int _widthField = 40;

        private List<Point> _body;
        private Point _head;
        private Point _tail;
        private int _length = 1;
        private Directions _directory;

        public Snake(int x, int y) : this(x, y, 1) { }

        public Snake(int x, int y, int length) {
            _length = length;
            _body = new List<Point>(_length);
            x -= _length;

            for (int i = 0; i < _length; i++) {
                x++;
                var point = new Point(
                        x,
                        y,
                        SymbolSnake);
                point.Draw();
                _body.Add(point);
            }

            _head = _body.Last();
        }

        public Directions Direction {
            get => _directory;
            set => _directory = value;
        }

        public void Move() {
            _head = GetNextPoint();
            _body.Add(_head);

            _tail = _body.First();
            _body.Remove(_tail);

            _head.Draw();
            _tail.Clear();

            Thread.Sleep(100);
        }

        private Point GetNextPoint() {
            Point point = _head.Get;

            switch (_directory) {
                case Directions.Up:
                    --point.Y;
                    if (point.Y == 0)
                        point.Y = _heightField;
                    break;
                case Directions.Down:
                    ++point.Y;
                    if (point.Y == _heightField)
                        point.Y = 0;
                    break;
                case Directions.Right:
                    ++point.X;
                    if (point.X == _widthField)
                        point.X = 0;
                    break;
                case Directions.Left:
                    --point.X;
                    if (point.X == 0)
                        point.X = _widthField;
                    break;
            }

            return point;
        }
    }
}
