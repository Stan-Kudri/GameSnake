using GameSnake.Enum;

namespace Core.Components
{
    public abstract class UserInput
    {
        protected Directions _currentDirection = Directions.Right;

        public UserInput(Directions directions = Directions.Right) => _currentDirection = directions;

        public event Action<UserInput>? OnChangedDirection;

        public Directions CurrentDirection => _currentDirection;

        public abstract void Update();

        protected void ChangeDirection(Directions direction)
        {
            switch (direction)
            {
                case Directions.Up:
                case Directions.Down:
                    if (_currentDirection != Directions.Up && _currentDirection != Directions.Down)
                    {
                        _currentDirection = direction;
                        OnChangedDirection?.Invoke(this);
                    }

                    break;

                case Directions.Right:
                case Directions.Left:
                    if (_currentDirection != Directions.Right && _currentDirection != Directions.Left)
                    {
                        _currentDirection = direction;
                        OnChangedDirection?.Invoke(this);
                    }

                    break;
            }
        }
    }
}
