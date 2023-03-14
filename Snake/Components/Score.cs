using GameSnake.Components.ItemGameMap;

namespace GameSnake.Components
{
    public class Score
    {
        public const int StartWidthDisplay = 0;

        private readonly int _startHeightDisplay;

        public Score(GameMap map)
        {
            _startHeightDisplay = map.HeightBoard() + 2;
            map.OnEatScore += Increase;
        }

        public int Points { get; private set; } = 0;

        public void Draw()
        {
            var scoreLine = $"Score : {Points}";

            Console.SetCursorPosition(0, _startHeightDisplay);
            Console.Write(scoreLine);
        }

        private void Increase(Food food) => Points += food.Score;
    }
}
