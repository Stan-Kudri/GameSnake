using Core.Components.GameMapItems;
using GameSnake.Extension;

namespace GameSnake.ComponentsGame.ItemGameMap
{
    public class SnakeConsole : Snake
    {
        private const char SymbolSnake = 'О';

        public SnakeConsole(Border border)
            : base(border)
        {
        }

        public override void Draw() => Body.ForEach(x => x.Draw(SymbolSnake));
    }
}
