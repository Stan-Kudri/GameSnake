using GameSnake.Components.ItemGameMap;

namespace GameSnake.Components
{
    public class Score
    {
        public const int StartWidthDisplay = 0;

        private readonly int _startHeightDisplay;

        public Score(int height)
        {
            _startHeightDisplay = height + 2;
        }

        public int Points { get; private set; } = 0;

        public void Draw()
        {
            var scoreLine = $"Score : {Points}";

            Console.SetCursorPosition(0, _startHeightDisplay);
            Console.Write(scoreLine);
        }

        public void Increase(Food food) => Points += food.Score;
    }
}
