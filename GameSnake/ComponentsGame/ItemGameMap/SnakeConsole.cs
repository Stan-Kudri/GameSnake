using Core.Components.GameMapItems;
using GameSnake.Enum;
using GameSnake.Extension;

namespace GameSnake.ComponentsGame.ItemGameMap
{
    public class SnakeConsole : Snake
    {
        private const char SymbolSnake = 'О';
        private const int DividerLengthHalf = 2;

        public SnakeConsole(int x, int y, Border border, int length = 1)
            : base(x, y, border, length)
        {
        }

        public SnakeConsole(Border border, int length = StartLength, Directions directions = StartDirection)
            : base(
                  (border.Width / DividerLengthHalf) - length,
                  border.Height / DividerLengthHalf,
                  border,
                  length,
                  directions)
        {
        }

        public override void Draw() => Body.ForEach(x => x.Draw(SymbolSnake));
    }
}
