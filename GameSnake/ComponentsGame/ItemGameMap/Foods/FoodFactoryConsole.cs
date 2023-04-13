using Core;
using Core.Components.GameMapItems.Foods;

namespace GameSnake.ComponentsGame.ItemGameMap.Foods
{
    public class FoodFactoryConsole : FoodFactory
    {
        public override Food Create(Point point)
        {
            return new FoodConsole(point);
        }
    }
}
