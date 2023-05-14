using Core;
using Core.Components.GameMapItems.Foods;

namespace GameSnake.ComponentsGame.ItemGameMap.Foods
{
    public class FoodFactoryConsole : FoodFactory
    {
        public override Food Create(Points point) => new FoodConsole(point);
    }
}
