using GameSnake.Enum;
using GameSnake.Extension;

namespace GameSnake.Components.ItemGameMap {
    public class Snake {
        public const char SymbolSnake = 'О';

        private readonly int _heightField;
        private readonly int _widthField;
        private readonly List<Point> _body;

        private Point _head;

        public Snake(int x, int y, Border field) : this(x, y, field, 1) { }

        public Snake(int x, int y, Border field, int length) {
            Length = length;
            _body = new List<Point>(Length);
            _heightField = field.Height;
            _widthField = field.Width;
            BuildBody(x, y);
        }

        public Directions Direction { get; set; } = Directions.Right;

        public int Length { get; private set; }

        private Point NextPoint {
            get {
                Point position = _head.Clone();

                switch (Direction) {
                    case Directions.Up:
                        --position.Y;
                        break;
                    case Directions.Down:
                        ++position.Y;
                        break;
                    case Directions.Right:
                        ++position.X;
                        break;
                    case Directions.Left:
                        --position.X;
                        break;
                }

                position.X = ClampInverted(position.X, 1, _widthField - 1);
                position.Y = ClampInverted(position.Y, 1, _heightField - 1);

                return position;
            }
        }

        public void Move() {
            _head = NextPoint;
            _body.Add(_head);
            _body.Remove(_body.First());
        }

        public bool EatFood(Point food) {
            if (food.Equals(NextPoint)) {
                _head = NextPoint;
                Length++;
                _body.Add(_head);

                return true;
            }

            return false;
        }

        public void Draw() => _body.ForEach(x => x.Draw(SymbolSnake));

        public void Clear() => _body.ForEach(x => x.Clear());

        public bool Intersect() {
            for (var i = 1; i < Length - 1; i++) {
                if (_head.Equals(_body[i])) {
                    return true;
                }
            }

            return false;
        }

        public bool IntersectBody(Point food) => _body.Contains(food);

        private int ClampInverted(int position, int min, int max) {
            if (position < min) {
                return max;
            }
            else if (position > max) {
                return min;
            }

            return position;
        }

        private void BuildBody(int x, int y) {
            for (int i = 0; i < Length; i++) {
                x++;
                var position = new Point(x, y);
                _body.Add(position);
            }

            _head = _body.Last();
        }
    }
}
