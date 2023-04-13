using Core;
using Core.Components.GameMapItems.Foods;
using GameSnake.Extension;

namespace GameSnake.ComponentsGame.ItemGameMap.Foods
{
    public class FoodConsole : Food
    {
        public const char SymbolEat = '@';

        public FoodConsole(Point position, int scorePoint = 1)
            : base(position, scorePoint)
        {
        }

        public override void Draw()
        {
            Position.Draw(SymbolEat);
        }

        public override void Clear()
        {
            Position.Clear();
        }
    }
}
