using Core.Components.GameMapItems;
using GameSnake.Enum;
using GameSnake.Extension;

namespace GameSnake.ComponentsGame.ItemGameMap
{
    public class SnakeConsole : Snake
    {
        private const char SymbolSnake = 'О';

        public SnakeConsole(int x, int y, Border border, int length = StartLength, Directions directions = StartDirection)
            : base(x, y, border, length, directions)
        {
        }

        public override void Draw() => Body.ForEach(x => x.Draw(SymbolSnake));
    }
}
