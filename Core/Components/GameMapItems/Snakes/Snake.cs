using Core.Components.GameMapItems.Borders;
using GameSnake.Enum;

namespace Core.Components.GameMapItems.Snakes
{
    public abstract class Snake
    {
        private readonly List<Point> _border;
        private readonly int _heightField;
        private readonly int _widthField;

        private int _length;
        private Point _head;
        private Point _oldTail;

        protected readonly List<Point> Body;

        public Snake(int x, int y, Border border, int length = 1, Directions directions = Directions.Right)
        {
            if (x >= border.Width)
            {
                throw new ArgumentException("The position X of the snake is incorrect.", nameof(x));
            }

            if (y >= border.Height)
            {
                throw new ArgumentException("The position Y of the snake is incorrect.", nameof(y));
            }

            _length = length;
            _border = border.Borders;
            _widthField = border.Width;
            _heightField = border.Height;
            Direction = directions;
            Body = BuildBody(x, y);
            _head = Body.First();
            _oldTail = Body.Last();
        }

        public Directions Direction { get; set; }

        public Point Head => _head;

        public void Move()
        {
            _head = GetNewHeadPosition();
            _oldTail = Body.First();

            if (ObstacleCollision())
            {
                return;
            }

            _head.X = ClampInverted(_head.X, 1, _widthField - 1);
            _head.Y = ClampInverted(_head.Y, 1, _heightField - 1);

            Body.Add(_head);
            Body.Remove(Body.First());
        }

        public bool TryEatFood(Point food)
        {
            if (food.Equals(_head))
            {
                _length++;
                Body.Insert(0, _oldTail);
                return true;
            }

            return false;
        }

        public abstract void Draw();

        public abstract void Clear();

        public bool ObstacleCollision()
        {
            foreach (var obstacle in _border)
            {
                if (obstacle.Equals(_head))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Intersect()
        {
            for (var i = _length - 2; i > 0; i--)
            {
                if (_head.Equals(Body[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IntersectBody(Point food) => Body.Contains(food);

        private Point GetNewHeadPosition()
        {
            var position = _head.Clone();

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

        private List<Point> BuildBody(int x, int y)
        {
            var body = new List<Point>();

            if (_length == 1)
            {
                body.Add(new Point(x, y));
            }
            else
            {
                for (var i = 0; i < _length; i++)
                {
                    x++;
                    var position = new Point(x, y);
                    body.Add(position);
                }
            }

            return body;
        }
    }
}
