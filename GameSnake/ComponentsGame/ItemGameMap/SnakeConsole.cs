using Core.Components.GameMapItems;
using GameSnake.Enum;
using GameSnake.Extension;

namespace GameSnake.ComponentsGame.ItemGameMap
{
    public class SnakeConsole : Snake
    {
        public const char SymbolSnake = 'О';

        public SnakeConsole(int x, int y, Border border, int length = 1, Directions directions = Directions.Right)
            : base(x, y, border, length, directions)
        {
        }

        public override void Draw() => Body.ForEach(x => x.Draw(SymbolSnake));

        public override void Clear() => Body.ForEach(x => x.Clear());
    }
}
