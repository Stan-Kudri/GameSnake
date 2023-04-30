using System;
using Core.Components;
using GameSnake.Enum;

namespace MonoGameSnake.ComponentsGame
{
    public class UserInput : IUserInput
    {
        private Directions _currentDirection = Directions.Right;

        public UserInput(Directions direction = Directions.Right) => _currentDirection = direction;

        public Directions CurrentDirection => _currentDirection;

        public event Action<IUserInput> OnChangedDirection;

        public void Update()
        {
        }

        public void Update(Directions newDirection)
        {
            if (ChangeDirection(newDirection))
            {
                OnChangedDirection?.Invoke(this);
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
