using GameSnake.Components.ItemGameMap;

namespace GameSnake.Components
{
    public class Score
    {
        public const int StartWidthDisplay = 0;
        public const int OffsetPositionHeight = 2;

        public event Action? OnUpIntervalScore;

        private readonly int _startHeightDisplay;
        private readonly int _speedUpInterval;

        private int _numberInterval = 0;

        public Score(int height, int points = 0, int speedUpInterval = 5)
        {
            _startHeightDisplay = height + OffsetPositionHeight;
            Points = points;
            _speedUpInterval = speedUpInterval;
        }

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
            if (Points == (_numberInterval + 1) * _speedUpInterval)
            {
                _numberInterval++;
                OnUpIntervalScore?.Invoke();
            }
        }
    }
}
