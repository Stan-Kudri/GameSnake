using GameSnake.Components.ItemGameMap;

namespace GameSnake.Components
{
    public class Score
    {
        public const int StartWidthDisplay = 0;
        public const int OffsetPositionHeight = 2;

        private readonly int _startHeightDisplay;

        public Score(int height, int points = 0)
        {
            _startHeightDisplay = height + OffsetPositionHeight;
            Points = points;
        }

        public int Points { get; private set; }

        public void Draw()
        {
            var scoreLine = $"Score : {Points}";

            Console.SetCursorPosition(0, _startHeightDisplay);
            Console.Write(scoreLine);
        }

        public void Increase(Food food) => Points += food.Score;
    }
}
