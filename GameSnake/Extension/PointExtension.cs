using Core;

namespace GameSnake.Extension
{
    public static class PointExtension
    {
        private const char EmptyChar = ' ';

        public static void Draw(this Point position, char symbol) => position.DrawPoint(symbol);

        public static void Clear(this Point position) => position.DrawPoint(EmptyChar);

        private static void DrawPoint(this Point position, char symbol)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.WriteLine(symbol);
        }
    }
}
