using GameSnake.Components.ItemGameMap;
using GameSnake.Enum;

namespace GameSnake.ComponentsGame.ItemGameMap.SnakeType
{
    public class SnakeNotPassingBorders : Snake
    {
        private readonly int _heightField;
        private readonly int _widthField;

        public SnakeNotPassingBorders(int x, int y, Border field) : this(x, y, field, 1) { }

        public SnakeNotPassingBorders(int x, int y, Border field, int length) : base(x, y, length)
        {
            _heightField = field.Height;
            _widthField = field.Width;
        }

        public override bool Intersect()
        {
            if (IsEncounterTheBorder(_head))
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

        private bool IsEncounterTheBorder(Point point) => point.Y > _heightField || point.Y < 0 || point.X > _widthField || point.X < 0;
    }
}
