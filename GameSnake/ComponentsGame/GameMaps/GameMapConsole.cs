using Core.Components.GameMapItems.Borders;
using Core.Components.GameMapItems.Foods;
using Core.Components.GameMapItems.Snakes;
using Core.Components.GameMaps;
using GameSnake.ComponentsGame.ItemGameMap.Borders;
using GameSnake.ComponentsGame.ItemGameMap.Foods;
using GameSnake.ComponentsGame.ItemGameMap.Snakes;

namespace GameSnake.ComponentsGame.GameMaps
{
    public class GameMapConsole : GameMap
    {
        public GameMapConsole(BorderConsole border, SnakeConsole snake)
            : this(border, snake, new FoodFactoryConsole())
        {
        }

        public GameMapConsole(BorderConsole border, SnakeConsole snake, FoodFactoryConsole foodFactory)
            : base(border, snake, foodFactory)
        {
        }

        public GameMapConsole(Border border, Snake snake, FoodFactory foodFactoryConsole)
            : base(border, snake, foodFactoryConsole)
        {
        }

        public override void Draw()
        {
            _snake.Draw();
            _food.Draw();
            _border.Draw();
        }

        public override void Clear()
        {
            _snake.Clear();
            _food.Clear();
        }
    }
}
