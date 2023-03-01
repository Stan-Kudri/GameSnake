using GameSnake.Enum;

namespace GameSnake {
    public class Snake {
        public const char SymbolSnake = 'o';

        private int _heightField;
        private int _widthField;

        private List<Point> _body;
        private Point _head;
        private Point _tail;
        private int _length = 1;
        private Directions _directory = Directions.Right;

        public Snake(int x, int y, Field field) : this(x, y, field, 1) { }

        public Snake(int x, int y, Field field, int length) {
            _length = length;
            _body = new List<Point>(_length);
            _heightField = field.Height;
            _widthField = field.Width;
            BuildTheSnakeBody(x, y);
        }

        public Directions Direction {
            get => _directory;
            set => _directory = value;
        }

        public void Move() {
            _head = NextPoint;
            if (TheEnd(_head)) {
                throw new Exception("Game Over");
            }
            _body.Add(_head);

            _tail = _body.First();
            _body.Remove(_tail);

            _tail.Clear();
            _head.Draw();

            Thread.Sleep(100);
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

        private void BuildTheSnakeBody(int x, int y) {
            x -= _length;

            for (int i = 0; i < _length; i++) {
                x++;
                var point = new Point(x, y, SymbolSnake);
                _body.Add(point);
                point.Draw();
            }

            _head = _body.Last();
        }

        private bool TheEnd(Point point) {
            for (var i = 1; i < _length - 1; i++) {
                if (point.Equals(_body[i])) {
                    return true;
                }
            }
            return false;
        }
    }
}
