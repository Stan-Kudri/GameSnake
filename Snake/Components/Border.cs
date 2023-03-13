using GameSnake.Extension;

namespace GameSnake.Components {
    public class Border {
        public const char SymbolField = '*';

        private List<Point> _borders;

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Border(int width, int height) {
            if (width < 1 || height < 1) {
                throw new ArgumentException("Invalid board size.");
            }

            Width = width;
            Height = height;

            _borders = new List<Point>();
            Create();
        }

        public void Draw() => _borders.ForEach(x => x.Draw(SymbolField));

        private void Create() {
            for (var x = 0; x <= Width; x++) {
                for (var y = 0; y <= Height; y++) {
                    if (y == 0 || y == Height || x == 0 || x == Width) {
                        var position = new Point(x, y);
                        _borders.Add(position);
                    }
                }
            }
        }
    }
}
