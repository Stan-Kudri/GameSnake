using GameSnake.Components.ItemGameMap;
using GameSnake.ComponentsGame.ItemGameMap.SnakeType;
using GameSnake.Enum;

namespace GameSnake.Extension
{
    public static class SnakeTypeExtension
    {
        public static Snake CreateSnake(this TypeSnake type, Border border, int snakeLength = 10)
        {
            if (type == TypeSnake.NotPassingBorders)
            {
                return new SnakeNotPassingBorders((border.Height / 2) - snakeLength, border.Height / 2, border, snakeLength);
            }
            else if (type == TypeSnake.PassingBorders)
            {
                return new SnakePassingBorders((border.Width / 2) - snakeLength, border.Height / 2, border, snakeLength);
            }
            else
            {
                throw new ArgumentException("Unknown type of snake.");
            }
        }
    }
}
