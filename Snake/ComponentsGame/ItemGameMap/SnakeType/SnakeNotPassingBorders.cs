using GameSnake.Components.ItemGameMap;
using GameSnake.Enum;

namespace GameSnake.ComponentsGame.ItemGameMap.SnakeType
{
    public class SnakeNotPassingBorders : Snake
    {
        private protected readonly List<Point> _border;

        public SnakeNotPassingBorders(int x, int y, Border border) : this(x, y, border, 1) { }

        public SnakeNotPassingBorders(int x, int y, Border border, int length) : base(x, y, length)
        {
            _border = border.Borders;
        }

        public override bool Intersect()
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

        private protected override Point GetNewHeadPosition()
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

        private bool ObstacleCollision()
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
    }
}
