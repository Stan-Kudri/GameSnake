namespace GameSnake.Components {
    public class Score {
        public const string TitleScoreLine = "Score : ";
        public const int StartWidthDisplay = 0;

        private int _startHeightDisplay;

        public Score(int points, int height) {
            if (points == 0) {
                throw new ArgumentException("Points greater than zero.");
            }

            _startHeightDisplay = height + 2;
            Points = points;
        }

        public int Points { get; private set; }

        public void Draw() {
            Console.SetCursorPosition(0, _startHeightDisplay);
            var scoreLine = $"{TitleScoreLine}{Points}";
            Console.Write(scoreLine);
        }

        public void Add(int points = 1) => Points += points;
    }
}
