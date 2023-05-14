using Core.Components;
using GameSnake.Enum;

namespace GameSnake.ComponentsGame
{
    public class UserInputConsole : UserInput
    {
        public UserInputConsole(Directions direction = Directions.Right)
            : base(direction)
        {
        }

        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey().Key;
                var direction = ToDirection(key);
                ChangeDirection(direction);
            }
        }

        public Directions ToDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return Directions.Up;
                case ConsoleKey.DownArrow:
                    return Directions.Down;
                case ConsoleKey.LeftArrow:
                    return Directions.Left;
                case ConsoleKey.RightArrow:
                    return Directions.Right;
                default:
                    return Directions.Unknown;
            }
        }
    }
}
