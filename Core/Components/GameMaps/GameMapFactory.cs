using Core.Components.GameMapItems;
using Core.Components.GameMapItems.Foods;

namespace Core.Components.GameMaps
{
    public abstract class GameMapFactory
    {
        public abstract GameMap Create(Border border, Snake snake, FoodFactory foodFactory);
    }
}
