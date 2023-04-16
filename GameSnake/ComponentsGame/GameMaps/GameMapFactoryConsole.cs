using Core.Components.GameMapItems.Borders;
using Core.Components.GameMapItems.Foods;
using Core.Components.GameMapItems.Snakes;
using Core.Components.GameMaps;

namespace GameSnake.ComponentsGame.GameMaps
{
    public class GameMapFactoryConsole : GameMapFactory
    {
        public override GameMap Create(Border border, Snake snake, FoodFactory foodFactory) => new GameMapConsole(border, snake, foodFactory);
    }
}
