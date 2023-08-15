namespace Core.Components
{
    public class BorderSize
    {
        private const int DefaultWidthValue = 20;
        private const int DefaultHeightValue = 20;

        public BorderSize(int width = DefaultWidthValue, int height = DefaultHeightValue)
        {
            if (width < 1 || height < 1)
            {
                throw new ArgumentException("Invalid board size.");
            }

            Width = width;
            Height = height;
        }

        public int Width { get; private set; }

        public int Height { get; private set; }
    }
}
