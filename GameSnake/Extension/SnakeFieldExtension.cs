using GameSnake.ComponentsGame.ItemGameMap;

namespace GameSnake.Extension
{
    public static class SnakeFieldExtension
    {
        public static Snake Create(this Border border, int length) => new Snake((border.Width / 2) - length, border.Height / 2, border, length);
    }
}
