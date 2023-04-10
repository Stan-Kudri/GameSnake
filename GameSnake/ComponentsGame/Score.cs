using GameSnake.ComponentsGame.ItemGameMap;

namespace GameSnake.ComponentsGame
{
    public class Score
    {
        public const int StartWidthDisplay = 0;
        public const int OffsetPositionHeight = 2;

        private readonly int _startHeightDisplay;

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

        public void Draw()
        {
            var scoreLine = $"Score : {Points}";

            Console.SetCursorPosition(0, _startHeightDisplay);
            Console.Write(scoreLine);
        }

        public void Increase(Food food)
        {
            Points += food.Score;
            OnUpIntervalScore?.Invoke(Points);
        }
    }
}
