namespace GameSnake {
    public class Point {
        public int _x;
        public int _y;
        private readonly char _symbol;

        public Point(int x, int y, char symbol) {
            _x = x;
            _y = y;
            _symbol = symbol;
        }

        public void Draw() {
            DrawPoint(_symbol);
        }

        public void Clear() {
            DrawPoint(' ');
        }

        private void DrawPoint(char symbol) {
            Console.SetCursorPosition(_x, _y);
            Console.WriteLine(symbol);
        }
    }
}
