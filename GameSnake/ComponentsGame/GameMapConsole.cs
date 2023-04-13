using Core.Components;
using GameSnake.ComponentsGame.ItemGameMap;
using GameSnake.ComponentsGame.ItemGameMap.Foods;

namespace GameSnake.ComponentsGame
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
