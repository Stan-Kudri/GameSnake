using GameSnake.Components.ItemGameMap;
using GameSnake.Enum;

namespace GameSnake.ComponentsGame.ItemGameMap.SnakeType
{
    public class SnakePassingBorders : Snake
    {
        private readonly int _heightField;
        private readonly int _widthField;

        public SnakePassingBorders(int x, int y, Border field) : this(x, y, field, 1) { }

        public SnakePassingBorders(int x, int y, Border field, int length) : base(x, y, length)
        {
            _heightField = field.Height;
            _widthField = field.Width;
        }

        public override bool Intersect()
        {
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
    }
}
