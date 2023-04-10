using GameSnake.Enum;
using GameSnake.Extension;

namespace GameSnake.ComponentsGame
{
    public class UserInput
    {
        public UserInput(Directions direction = Directions.Right) => CurrentDirection = direction;

        public event Action<UserInput>? OnChangedDirection;

        public Directions CurrentDirection { get; private set; }

        public void Update()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;
                var direct = key.ToDirection();
                if (ChangeDirection(direct))
                {
                    OnChangedDirection?.Invoke(this);
                }
            }
        }

        private bool ChangeDirection(Directions direction)
        {
            switch (direction)
            {
                case Directions.Up:
                case Directions.Down:
                    if (CurrentDirection != Directions.Up && CurrentDirection != Directions.Down)
                    {
                        CurrentDirection = direction;
                        return true;
                    }

                    return false;
                case Directions.Right:
                case Directions.Left:
                    if (CurrentDirection != Directions.Right && CurrentDirection != Directions.Left)
                    {
                        CurrentDirection = direction;
                        return true;
                    }

                    return false;
            }

            return false;
        }
    }
}