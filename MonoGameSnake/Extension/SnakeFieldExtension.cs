using Core.Components.GameMapItems;
using MonoGameSnake.ComponentsGame.ItemGameMap;

namespace MonoGameSnake.Extension
{
    public static class SnakeFieldExtension
    {
        public const int DividerLengthHalf = 2;

        public static SnakeMono Creator(this Border border, int length = 4)
            => new SnakeMono((border.Width / DividerLengthHalf) - length, border.Height / DividerLengthHalf, border, length);
    }
}
