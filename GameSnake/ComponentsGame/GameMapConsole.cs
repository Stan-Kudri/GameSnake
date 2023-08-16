using Core.Components;
using Core.Components.GameMapItems;
using Core.Components.GameMapItems.Foods;
using GameSnake.ComponentsGame.ItemGameMap;
using GameSnake.ComponentsGame.ItemGameMap.Foods;
using GameSnake.Extension;

namespace GameSnake.ComponentsGame
{
    public class GameMapConsole : GameMap
    {
        public GameMapConsole(BorderConsole border, SnakeConsole snake)
            : this(border, snake, new FoodFactoryConsole())
        {
        }

        public GameMapConsole(Border border, Snake snake, FoodFactory foodFactoryConsole)
            : base(border, snake, foodFactoryConsole)
        {
        }

        public override void Clear()
        {
            Snake.Body.ForEach(x => x.Clear());
            Food.Position.Clear();
        }
    }
}
