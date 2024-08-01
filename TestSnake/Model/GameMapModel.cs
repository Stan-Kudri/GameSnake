using Core.Components;
using Core.Components.GameMapItems;
using Core.Components.GameMapItems.Foods;
using TestSnake.Model.ItemsGameMap.Foods;

namespace TestSnake.Model
{
    public class GameMapModel : GameMap
    {
        public GameMapModel(Border border, Snake snake)
            : this(border, snake, new FoodFactoryModel())
        {
        }

        public GameMapModel(Border border, Snake snake, FoodFactory foodFactory)
            : base(border, snake, foodFactory)
        {
        }
    }
}
