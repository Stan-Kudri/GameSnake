using GameSnake.Enum;
using GameSnake.Extension;

namespace GameSnake.Components.ItemGameMap
{
    public class Snake
    {
        public const char SymbolSnake = 'О';

        private readonly int _heightField;
        private readonly int _widthField;
        private readonly List<Point> _body;

        private int _length;
        private Point _head;

        public Snake(int x, int y, Border field) : this(x, y, field, 1) { }

        public Snake(int x, int y, Border field, int length)
        {
            _length = length;
            _body = new List<Point>(_length);
            _heightField = field.Height;
            _widthField = field.Width;
            BuildBody(x, y);
        }

        public Directions Direction { get; set; } = Directions.Right;

        public void Move()
        {
            _head = NextPoint();
            _body.Add(_head);
            _body.Remove(_body.First());
        }

        public bool EatFood(Point food)
        {
            if (food.Equals(NextPoint()))
            {
                _head = NextPoint();
                _length++;
                _body.Add(_head);

                return true;
            }

            return false;
        }

        public void Draw() => _body.ForEach(x => x.Draw(SymbolSnake));

        public void Clear() => _body.ForEach(x => x.Clear());

        public bool Intersect()
        {
            var newPositionHead = NextPoint();

            for (var i = _length - 1; i > 0; i--)
            {
                if (newPositionHead.Equals(_body[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IntersectBody(Point food) => _body.Contains(food);

        private Point NextPoint()
        {
            Point position = _head.Clone();

            switch (Direction)
            {
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

        private int ClampInverted(int position, int min, int max)
        {
            if (position < min)
            {
                return max;
            }
            else if (position > max)
            {
                return min;
            }

            return position;
        }

        private void BuildBody(int x, int y)
        {
            for (int i = 0; i < _length; i++)
            {
                x++;
                var position = new Point(x, y);
                _body.Add(position);
            }

            _head = _body.Last();
        }
    }
}
