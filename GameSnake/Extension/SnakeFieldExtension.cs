using GameSnake.ComponentsGame.ItemGameMap;

namespace GameSnake.Extension
{
    public static class SnakeFieldExtension
    {
        public static SnakeConsole Create(this BorderConsole border, int length) => new SnakeConsole((border.Width / 2) - length, border.Height / 2, border, length);
    }
}
