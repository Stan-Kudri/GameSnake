using Core;
using Core.Components.GameMapItems.Foods;

namespace TestSnake.Model.ItemsGameMap.Foods
{
    public class FoodFactoryModel : FoodFactory
    {
        public override Food Create(Point point) => new FoodModel(point);
    }
}
