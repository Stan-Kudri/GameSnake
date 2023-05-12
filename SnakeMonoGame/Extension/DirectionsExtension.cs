using GameSnake.Enum;
using Microsoft.Xna.Framework.Input;

namespace SnakeMonoGame.Extension
{
    public static class DirectionsExtension
    {
        public static Directions ToDirection(this KeyboardState key)
        {
            if (key.IsKeyDown(Keys.Up))
            {
                return Directions.Up;
            }
            if (key.IsKeyDown(Keys.Down))
            {
                return Directions.Down;
            }
            if (key.IsKeyDown(Keys.Left))
            {
                return Directions.Left;
            }
            if (key.IsKeyDown(Keys.Right))
            {
                return Directions.Right;
            }
            else
            {
                return Directions.Unknown;
            }
        }
    }
}
