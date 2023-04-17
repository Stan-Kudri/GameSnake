using Core.Components.GameMapItems;
using Core.Components.GameMapItems.Snakes;

namespace Core.Extension
{
    public static class SnakeFieldExtension
    {
        public const int DividerLengthHalf = 2;

        public static Snake Creator(this SnakeFactory snakeFactory, Border border, int length)
            => snakeFactory.Create((border.Width / DividerLengthHalf) - length, border.Height / DividerLengthHalf, border, length);
    }
}
