namespace GameSnake.Extension {
    public static class PointExtension {
        private const char EmptyChar = ' ';

        public static void Draw(this Point position, char symbol) {
            DrawPoint(position, symbol);
        }

        public static void Clear(this Point position) {
            DrawPoint(position, EmptyChar);
        }

        private static void DrawPoint(Point position, char symbol) {
            Console.SetCursorPosition(position.X, position.Y);
            Console.WriteLine(symbol);
        }
    }
}
