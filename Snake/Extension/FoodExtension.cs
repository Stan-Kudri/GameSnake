using GameSnake.Components;

namespace GameSnake.Extension {
    public static class FoodExtension {
        private const int MinCoordinatePoint = 1;//Because the border value is 0.
        private static Random random = new Random();

        public static Point GeneratePosition(this Border field) {
            return new Point(
                random.Next(MinCoordinatePoint, field.Width - 1),
                random.Next(MinCoordinatePoint, field.Height - 1));
        }
    }
}
