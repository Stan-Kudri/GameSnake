namespace GameSnake {
    public class Point {
        private readonly char _symbol;

        public Point(int x, int y, char symbol) {
            X = x;
            Y = y;
            _symbol = symbol;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Point Get => new Point(X, Y, _symbol);

        public void Draw() {
            DrawPoint(_symbol);
        }

        public void Clear() {
            DrawPoint(' ');
        }

        private void DrawPoint(char symbol) {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(symbol);
        }

        public override int GetHashCode() {
            return HashCode.Combine(X, Y, _symbol);
        }

        public override bool Equals(object? obj) {
            return Equals(obj as Point);
        }

        private bool Equals(Point? point) {
            if (point == null) {
                return false;
            }

            return point.X == X && point.Y == Y && point._symbol == _symbol;
        }
    }
}
