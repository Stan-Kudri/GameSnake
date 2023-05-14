using Core;

namespace GameSnake.Extension
{
    public static class PointExtension
    {
        private const char EmptyChar = ' ';

        public static void Draw(this Points position, char symbol) => position.DrawPoint(symbol);

        public static void Clear(this Points position) => position.DrawPoint(EmptyChar);

        private static void DrawPoint(this Points position, char symbol)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.WriteLine(symbol);
        }
    }
}
