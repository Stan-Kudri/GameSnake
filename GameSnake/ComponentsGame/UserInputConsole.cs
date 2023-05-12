using Core.Components;
using Core.Extension;
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
                var direction = key.ToDirection();
                ChangeDirection(direction);
            }
        }
    }
}
