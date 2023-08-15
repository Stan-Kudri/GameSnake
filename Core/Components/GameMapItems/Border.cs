namespace Core.Components.GameMapItems
{
    public abstract class Border
    {
        public Border(BorderSize sizeField)
        {
            Width = sizeField.Width;
            Height = sizeField.Height;
            Borders = Create();
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public List<Point> Borders { get; protected set; }

        public abstract void Draw();

        private List<Point> Create()
        {
            var border = new List<Point>();

            for (var x = 0; x <= Width; x++)
            {
                for (var y = 0; y <= Height; y++)
                {
                    if (y == 0 ||
                        y == Height ||
                        x == 0 ||
                        x == Width)
                    {
                        var position = new Point(x, y);
                        border.Add(position);
                    }
                }
            }

            return border;
        }
    }
}
