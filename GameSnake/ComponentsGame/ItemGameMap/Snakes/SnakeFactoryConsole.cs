using Core.Components.GameMapItems.Borders;
using Core.Components.GameMapItems.Snakes;
using GameSnake.Enum;

namespace GameSnake.ComponentsGame.ItemGameMap.Snakes
{
    public class SnakeFactoryConsole : SnakeFactory
    {
        public override SnakeConsole Create(int x, int y, Border border, int length = 1, Directions directions = Directions.Right)
            => new SnakeConsole(x, y, border, length, directions);
    }
}
