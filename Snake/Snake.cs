using GameSnake.Enum;

namespace GameSnake {
    public class Snake {
        public const char SymbolSnake = 'o';

        private int _heightField;
        private int _widthField;

        private List<Point> _body;
        private Point _head;
        private int _length = 1;
        private Directions _directory = Directions.Right;

        public Snake(int x, int y, Field field) : this(x, y, field, 1) { }

        public Snake(int x, int y, Field field, int length) {
            _length = length;
            _body = new List<Point>(_length);
            _heightField = field.Height;
            _widthField = field.Width;
            BuildBody(x, y);
        }

        public Directions Direction {
            get => _directory;
            set => _directory = value;
        }

        public bool Move() {
            _head = NextPoint;
            if (ClashPoint(_head)) {
                return false;
            }

            _body.Add(_head);

            var tail = _body.First();
            _body.Remove(tail);

            tail.Clear();
            _head.Draw();

            return true;
        }

        private Point NextPoint {
            get {
                Point point = _head.Get;

                switch (_directory) {
                    case Directions.Up:
                        --point.Y;
                        if (point.Y == 0)
                            point.Y = _heightField - 1;
                        break;
                    case Directions.Down:
                        ++point.Y;
                        if (point.Y == _heightField)
                            point.Y = 1;
                        break;
                    case Directions.Right:
                        ++point.X;
                        if (point.X == _widthField - 1)
                            point.X = 1;
                        break;
                    case Directions.Left:
                        --point.X;
                        if (point.X == 0)
                            point.X = _widthField - 1;
                        break;
                }

                return point;
            }
        }

        private void BuildBody(int x, int y) {
            x -= _length;

            for (int i = 0; i < _length; i++) {
                x++;
                var point = new Point(x, y, SymbolSnake);
                _body.Add(point);
                point.Draw();
            }

            _head = _body.Last();
        }

        private bool ClashPoint(Point movePoint) {
            for (var i = 1; i < _length - 1; i++) {
                if (movePoint.Equals(_body[i])) {
                    foreach (var point in _body) {
                        point.Clear();
                    }
                    return true;
                }
            }

            return false;
        }
    }
}
