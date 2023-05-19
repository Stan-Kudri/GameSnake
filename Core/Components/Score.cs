using Core.Components.GameMapItems.Foods;

namespace Core.Components
{
    public abstract class Score
    {
        protected const int StartPoints = 0;

        protected int _startHeightDisplay;

        public Score(int height, int points = StartPoints)
        {
            if (points < 0)
            {
                throw new ArgumentException("Points are not negative.", nameof(points));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height greater than one.", nameof(height));
            }

            var offSetPositionHight = 2;
            _startHeightDisplay = height + offSetPositionHight;
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
