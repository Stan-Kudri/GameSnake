using Core.Components;
using Core.Extension;
using GameSnake.Enum;

namespace GameSnake.ComponentsGame
{
    public class UserInput : IUserInput
    {
        private Directions _currentDirection;

        public UserInput(Directions direction = Directions.Right) => _currentDirection = direction;

        public UserInput()
        {
        }

        public event Action<IUserInput>? OnChangedDirection;

        public Directions CurrentDirection => _currentDirection;

        public void UpDate()
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
                    if (_currentDirection != Directions.Up && _currentDirection != Directions.Down)
                    {
                        _currentDirection = direction;
                        return true;
                    }

                    return false;
                case Directions.Right:
                case Directions.Left:
                    if (_currentDirection != Directions.Right && _currentDirection != Directions.Left)
                    {
                        _currentDirection = direction;
                        return true;
                    }

                    return false;
            }

            return false;
        }
    }
}
