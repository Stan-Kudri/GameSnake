using GameSnake.Enum;
using GameSnake.Extension;

namespace GameSnake.ComponentsGame.ItemGameMap.SnakeType
{
    public abstract class Snake : ISnake
    {
        public const char SymbolSnake = 'О';

        private protected readonly List<Point> _body;

        private protected int _length;
        private protected Point _head;

        public Snake()
        {
        }

        public Snake(int x, int y, int length)
        {
            _length = length;
            _body = new List<Point>(_length);
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

        public abstract bool Intersect();

        public bool IntersectBody(Point food) => _body.Contains(food);

        private protected abstract Point GetNewHeadPosition();

        private protected void BuildBody(int x, int y)
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
