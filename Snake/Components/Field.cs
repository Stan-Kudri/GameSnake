namespace GameSnake.Components {
    public class Field {
        public const char SymbolField = '*';
        private List<Point> _borders;

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Field(int width, int height) {
            if (width < 1 || height < 1) {
                throw new ArgumentException("Invalid board size.");
            }

            Width = width;
            Height = height;

            _borders = new List<Point>();

            HorizontalBorder(Width, 0);
            HorizontalBorder(Width, Height);
            VerticalBorder(0, Height);
            VerticalBorder(Width, Height);
        }

        private void HorizontalBorder(int x, int y) {
            for (var i = 0; i <= x; i++) {
                var point = new Point(i, y);
                _borders.Add(point);
                point.Draw(SymbolField);
            }
        }

        private void VerticalBorder(int x, int y) {
            for (var i = 1; i < y; i++) {
                var point = new Point(x, i);
                _borders.Add(point);
                point.Draw(SymbolField);
            }
        }

    }
}
