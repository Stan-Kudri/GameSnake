namespace GameSnake {
    public class Point {
        public Point(int x, int y) {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Point Clone() => new Point(X, Y);

        public override int GetHashCode() {
            return HashCode.Combine(X, Y);
        }

        public override bool Equals(object? obj) {
            return Equals(obj as Point);
        }

        private bool Equals(Point? position) {
            if (position == null) {
                return false;
            }

            return position.X == X && position.Y == Y;
        }
    }
}
