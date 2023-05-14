namespace Core.Components.GameMapItems
{
    public abstract class Border
    {
        public Border(int width, int height)
        {
            if (width < 1 || height < 1)
            {
                throw new ArgumentException("Invalid board size.");
            }

            Width = width;
            Height = height;

            Borders = Create();
        }

        public int Width { get; protected set; }

        public int Height { get; protected set; }

        public List<Points> Borders { get; protected set; }

        public abstract void Draw();

        protected List<Points> Create()
        {
            var border = new List<Points>();

            for (var x = 0; x <= Width; x++)
            {
                for (var y = 0; y <= Height; y++)
                {
                    if (y == 0 ||
                        y == Height ||
                        x == 0 ||
                        x == Width)
                    {
                        var position = new Points(x, y);
                        border.Add(position);
                    }
                }
            }

            return border;
        }
    }
}
