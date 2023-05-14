namespace Core
{
    public class Points
    {
        public Points(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Points Clone() => new Points(X, Y);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public override bool Equals(object? obj) => Equals(obj as Points);

        private bool Equals(Points? position)
        {
            if (position == null)
            {
                return false;
            }

            return position.X == X && position.Y == Y;
        }
    }
}
