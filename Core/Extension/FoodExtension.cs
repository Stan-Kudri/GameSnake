using Core.Components.GameMapItems;

namespace Core.Extension
{
    public static class FoodExtension
    {
        private const int MinCoordinatePoint = 1; // Because the border value is 0.

        private static readonly Random Random = new Random();

        public static Points GenerateFoodPosition(this Border field)
        {
            return new Points(
                Random.Next(MinCoordinatePoint, field.Width - 1),
                Random.Next(MinCoordinatePoint, field.Height - 1));
        }
    }
}
