namespace GameSnake.Extension {
    public static class PointExtension {
        private const char EmptyChar = ' ';

        public static void Draw(this Point point, char symbol) {
            DrawPoint(point, symbol);
        }

        public static void Clear(this Point point) {
            DrawPoint(point, EmptyChar);
        }

        private static void DrawPoint(Point point, char symbol) {
            Console.SetCursorPosition(point.X, point.Y);
            Console.WriteLine(symbol);
        }
    }
}
