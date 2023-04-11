using Core;
using Core.Components.GameMapItems;

namespace GameSnake.ComponentsGame.ItemGameMap
{
    public class FoodConsole : Food
    {
        public const char SymbolEat = '@';

        public FoodConsole(Point position, int scorePoint = 1)
            : base(position, scorePoint)
        {
        }
    }
}
