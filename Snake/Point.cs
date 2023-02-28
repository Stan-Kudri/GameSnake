namespace GameSnake {
    public class Point {
        private int _x;
        private int _y;
        private readonly char _symbol;

        public Point(int x, int y, char symbol) {
            _x = x;
            _y = y;
            _symbol = symbol;
        }

        public int X {
            get => _x;
            set => _x = value;
        }
        public int Y {
            get => _y;
            set => _y = value;
        }

        public Point Get => new Point(X, Y, _symbol);

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

        public override int GetHashCode() {
            return HashCode.Combine(_x, _y, _symbol);
        }

        public override bool Equals(object? obj) {
            return Equals(obj as Point);
        }

        private bool Equals(Point? point) {
            if (point == null) {
                return false;
            }
            return point._x == _x && point._y == _y && point._symbol == _symbol;
        }
    }
}
