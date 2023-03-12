namespace GameSnake.Components {
    public class Score {
        public const string TitleScoreLine = "Score : ";

        private int _startWidthDisplay;
        private int _startHeightDisplay;

        public Score(int points, Field field) {
            if (points == 0) {
                throw new ArgumentException("Points greater than zero.");
            }

            Points = points - 1;
            _startWidthDisplay = TitleScoreLine.Length;
            _startHeightDisplay = field.Height + 1;
            DrawTitleLine();
            Draw();
        }

        public int Points { get; private set; }

        public void Draw() {
            Console.SetCursorPosition(_startWidthDisplay, _startHeightDisplay);
            Console.Write(++Points);
        }

        private void DrawTitleLine() {
            Console.SetCursorPosition(0, _startHeightDisplay);
            Console.Write(TitleScoreLine);
        }
    }
}
