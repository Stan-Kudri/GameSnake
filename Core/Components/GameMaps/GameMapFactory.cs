using Core.Components.GameMapItems;
using Core.Components.GameMapItems.Foods;
using Core.Components.GameMapItems.Snakes;

namespace Core.Components.GameMaps
{
    public abstract class GameMapFactory
    {
        public abstract GameMap Create(Border border, Snake snake, FoodFactory foodFactory);
    }
}
