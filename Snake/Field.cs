namespace GameSnake {
    public class Field {
        private int _width;
        private int _height;
        private List<Point> _borders;

        public Field(int width, int height) {
            if (width < 1 && height < 1) {
                throw new ArgumentException("Value board not correct");
            }

            _width = width;
            _height = height;

            _borders = new List<Point>();

            HorizontalBorder(_width, 0);
            HorizontalBorder(_width, _height);
            VerticalBorder(0, _height);
            VerticalBorder(_width, _height);
        }

        private void HorizontalBorder(int x, int y) {
            for (var i = 0; i <= x; i++) {
                var point = new Point(i, y, '*');
                _borders.Add(point);
                point.Draw();
            }
        }

        private void VerticalBorder(int x, int y) {
            for (var i = 1; i < y; i++) {
                var point = new Point(x, i, '*');
                _borders.Add(point);
                point.Draw();
            }
        }

    }
}
