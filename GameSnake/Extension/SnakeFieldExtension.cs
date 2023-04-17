using Core.Components.GameMapItems;
using GameSnake.ComponentsGame.ItemGameMap;

namespace GameSnake.Extension
{
    public static class SnakeFieldExtension
    {
        public const int DividerLengthHalf = 2;

        public static Snake Creator(this Border border, int length)
            => new SnakeConsole((border.Width / DividerLengthHalf) - length, border.Height / DividerLengthHalf, border, length);
    }
}
