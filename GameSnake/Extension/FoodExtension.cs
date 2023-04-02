using GameSnake.Components.ItemGameMap;

namespace GameSnake.Extension
{
    public static class FoodExtension
    {
        private const int MinCoordinatePoint = 1; // Because the border value is 0.

        private static readonly Random Random = new Random();

        public static Point GenerateFoodPosition(this Border field)
        {
            return new Point(
                Random.Next(MinCoordinatePoint, field.Width - 1),
                Random.Next(MinCoordinatePoint, field.Height - 1));
        }
    }
}
