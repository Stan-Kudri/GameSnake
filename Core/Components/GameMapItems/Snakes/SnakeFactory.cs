using GameSnake.Enum;

namespace Core.Components.GameMapItems.Snakes
{
    public abstract class SnakeFactory
    {
        public abstract Snake Create(int x, int y, Border border, int length = 1, Directions directions = Directions.Right);
    }
}
