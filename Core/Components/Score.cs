using Core.Components.GameMapItems;

namespace Core.Components
{
    public abstract class Score
    {
        public const int StartWidthDisplay = 0;
        public const int OffsetPositionHeight = 2;

        protected int _startHeightDisplay;

        public Score(int height, int points = 0)
        {
            if (points < 0)
            {
                throw new ArgumentException("Points are not negative.", nameof(points));
            }

            _startHeightDisplay = height + OffsetPositionHeight;
            Points = points;
        }

        public event Action<int>? OnUpIntervalScore;

        public int Points { get; private set; }

        public abstract void Draw();

        public void Increase(Food food)
        {
            Points += food.Score;
            OnUpIntervalScore?.Invoke(Points);
        }
    }
}
