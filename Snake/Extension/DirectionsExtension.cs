using GameSnake.Enum;

namespace GameSnake.Extension {
    public static class DirectionsExtension {
        public static Directions GetDirection(this ConsoleKey key) {
            switch (key) {
                case ConsoleKey.UpArrow:
                    return Directions.Up;
                case ConsoleKey.DownArrow:
                    return Directions.Down;
                case ConsoleKey.LeftArrow:
                    return Directions.Left;
                case ConsoleKey.RightArrow:
                    return Directions.Right;
                default:
                    return Directions.Other;
            }
        }
    }
}
