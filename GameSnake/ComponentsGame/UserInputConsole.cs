using Core.Components;
using GameSnake.Enum;

namespace GameSnake.ComponentsGame
{
    public class UserInputConsole : UserInput
    {
        private readonly Dictionary<ConsoleKey, Directions> _directionMap = new Dictionary<ConsoleKey, Directions>
        {
            { ConsoleKey.UpArrow, Directions.Up },
            { ConsoleKey.DownArrow, Directions.Down },
            { ConsoleKey.LeftArrow, Directions.Left },
            { ConsoleKey.RightArrow, Directions.Right },
        };

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

        private Directions ToDirection(ConsoleKey key)
        {
            if (_directionMap.TryGetValue(key, out var directions))
            {
                return directions;
            }

            return Directions.Unknown;
        }
    }
}
