using System;
using Core.Components;
using GameSnake.Enum;
using Microsoft.Xna.Framework.Input;

namespace MonoGameSnake.ComponentsGame
{
    public class UserInput : IUserInput
    {
        private Directions _currentDirection = Directions.Right;

        private KeyboardState _oldKeyBoard;

        public UserInput(Directions direction = Directions.Right) => _currentDirection = direction;

        public Directions CurrentDirection => _currentDirection;

        public event Action<IUserInput> OnChangedDirection;

        public void Update()
        {
        }

        public bool Update(KeyboardState keyboardState)
        {
            if (ChangeDirection(keyboardState) && keyboardState != _oldKeyBoard)
            {
                _oldKeyBoard = keyboardState;
                OnChangedDirection?.Invoke(this);

                return true;
            }

            return false;
        }

        private bool ChangeDirection(KeyboardState keyboardState)
        {
            if (_currentDirection == Directions.Right || _currentDirection == Directions.Left)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    _currentDirection = Directions.Up;
                    return true;
                }
                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    _currentDirection = Directions.Down;
                    return true;
                }
            }
            else if (_currentDirection == Directions.Up || _currentDirection == Directions.Down)
            {
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    _currentDirection = Directions.Left;
                    return true;
                }
                else if (keyboardState.IsKeyDown(Keys.Right))
                {
                    _currentDirection = Directions.Right;
                    return true;
                }
            }

            return false;
        }
    }
}
