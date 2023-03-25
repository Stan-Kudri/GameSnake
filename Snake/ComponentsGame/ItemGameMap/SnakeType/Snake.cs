using GameSnake.Components.ItemGameMap;
using GameSnake.Enum;
using GameSnake.Extension;

namespace GameSnake.ComponentsGame.ItemGameMap.SnakeType
{
    public class Snake : ISnake
    {
        public const char SymbolSnake = 'О';

        private readonly List<Point> _body;
        private readonly List<Point> _border;
        private readonly int _heightField;
        private readonly int _widthField;

        private int _length;
        private Point _head;

        public Snake(int x, int y, Border border, int length)
        {
            _length = length;
            _body = new List<Point>(_length);
            _border = border.Borders;
            _widthField = border.Width;
            _heightField = border.Height;
            BuildBody(x, y);
        }

        public Directions Direction { get; set; } = Directions.Right;

        public void Move()
        {
            _body.Add(_head);
            _body.Remove(_body.First());
        }

        public bool EatFood(Point food)
        {
            _head = GetNewHeadPosition();

            if (food.Equals(_head))
            {
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
            if (ObstacleCollision())
            {
                return true;
            }

            for (var i = _length - 2; i > 0; i--)
            {
                if (_head.Equals(_body[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IntersectBody(Point food) => _body.Contains(food);

        private Point GetNewHeadPosition()
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

        private bool ObstacleCollision()
        {
            foreach (var obstacle in _border)
            {
                if (obstacle.Equals(_head))
                {
                    return true;
                }
            }

            _head.X = ClampInverted(_head.X, 1, _widthField - 1);
            _head.Y = ClampInverted(_head.Y, 1, _heightField - 1);

            return false;
        }
    }
}
