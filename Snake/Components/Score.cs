namespace GameSnake.Components {
    public class Score {
        public const int StartWidthDisplay = 0;

        private readonly int _startHeightDisplay;

        public Score(int points, int height) {
            if (points == 0) {
                throw new ArgumentException("Points greater than zero.");
            }

            _startHeightDisplay = height + 2;
            Points = points;
        }

        public int Points { get; private set; }

        public void Draw() {
            var scoreLine = $"Score : {Points}";

            Console.SetCursorPosition(0, _startHeightDisplay);
            Console.Write(scoreLine);
        }

        public void Increase(int points = 1) => Points += points;
    }
}
