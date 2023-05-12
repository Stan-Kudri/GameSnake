using Core.Components;
using GameSnake.Enum;
using GameSnake.Extension;

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
