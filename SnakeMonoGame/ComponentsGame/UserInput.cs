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

        public void Update(KeyboardState keyboardState)
        {
            if (ChangeDirection(keyboardState))
            {
                _oldKeyBoard = keyboardState;
                OnChangedDirection?.Invoke(this);
            }
        }

        public bool HasNewKey(KeyboardState keyboardState) => keyboardState != _oldKeyBoard;

        private bool ChangeDirection(KeyboardState keyboardState)
        {
            switch (_currentDirection)
            {
                case Directions.Right:
                case Directions.Left:
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
                    break;

                case Directions.Up:
                case Directions.Down:
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
                    break;
            }

            return false;
        }
    }
}
