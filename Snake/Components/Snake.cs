using GameSnake.Enum;
using GameSnake.Extension;

namespace GameSnake.Components {
    public class Snake {
        public const char SymbolSnake = 'О';

        private int _heightField;
        private int _widthField;

        private List<Point> _body;
        private Point _head;
        private Point _tail;
        private int _length = 1;

        public Snake(int x, int y, Field field) : this(x, y, field, 1) { }

        public Snake(int x, int y, Field field, int length) {
            _length = length;
            _body = new List<Point>(_length);
            _heightField = field.Height;
            _widthField = field.Width;
            BuildBody(x, y);
        }

        public Directions Direction { get; set; } = Directions.Right;

        public int Length => _length;

        public bool Intersect() {
            _head = NextPoint;

            for (var i = 1; i < _length - 1; i++) {
                if (_head.Equals(_body[i])) {
                    foreach (var point in _body) {
                        point.Clear();
                    }

                    return true;
                }
            }

            return false;
        }

        public void Move() {
            _tail = _body.First();
            _body.Add(_head);
            _body.Remove(_tail);
        }

        public bool EatFood(Point food) {
            if (food.Equals(_head)) {
                _length++;
                _body.Add(_head);

                return true;
            }

            return false;
        }

        public void DrawHead() => _head.Draw(SymbolSnake);

        public void ClearTail() => _tail.Clear();

        public bool IntersectBody(Point food) => _body.Contains(food);

        private Point NextPoint {
            get {
                Point position = _head.Clone();

                switch (Direction) {
                    case Directions.Up:
                        --position.Y;
                        if (position.Y == 0)
                            position.Y = _heightField - 1;
                        break;
                    case Directions.Down:
                        ++position.Y;
                        if (position.Y == _heightField)
                            position.Y = 1;
                        break;
                    case Directions.Right:
                        ++position.X;
                        if (position.X == _widthField - 1)
                            position.X = 1;
                        break;
                    case Directions.Left:
                        --position.X;
                        if (position.X == 0)
                            position.X = _widthField - 1;
                        break;
                }

                return position;
            }
        }

        private void BuildBody(int x, int y) {
            x -= _length;

            for (int i = 0; i < _length; i++) {
                x++;
                var position = new Point(x, y);
                _body.Add(position);
                position.Draw(SymbolSnake);
            }

            _tail = _body.First();
            _head = _body.Last();
        }
    }
}
