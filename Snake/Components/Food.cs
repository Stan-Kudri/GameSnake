using GameSnake.Extension;

namespace GameSnake.Components {
    public class Food {
        public const char SymbolEat = '@';
        public const int MinCoordinatePoint = 1;//Because the border value is 0.

        private int _heightField;
        private int _widthField;

        public Point Point { get; set; }

        private Random _random = new Random();

        public Food(Field field) {
            _heightField = field.Height;
            _widthField = field.Width;
            New();
        }

        public void New() {
            Point = new Point(
                _random.Next(MinCoordinatePoint, _widthField - 1),
                _random.Next(MinCoordinatePoint, _heightField - 1));
        }

        public void Draw() => Point.Draw(SymbolEat);

        public void Clear() => Point.Clear();
    }
}
