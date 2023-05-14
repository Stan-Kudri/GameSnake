using Core.Components;
using GameSnake.Enum;
using Microsoft.Xna.Framework.Input;

namespace MonoGameSnake.ComponentsGame
{
    public class UserInputMono : UserInput
    {
        public UserInputMono(Directions direction = Directions.Right)
            : base(direction)
        {
        }

        public override void Update()
        {
            var keyBoard = Keyboard.GetState();
            var direction = ToDirection(keyBoard);
            ChangeDirection(direction);
        }

        public Directions ToDirection(KeyboardState key)
        {
            if (key.IsKeyDown(Keys.Up))
            {
                return Directions.Up;
            }
            else if (key.IsKeyDown(Keys.Down))
            {
                return Directions.Down;
            }
            else if (key.IsKeyDown(Keys.Left))
            {
                return Directions.Left;
            }
            else if (key.IsKeyDown(Keys.Right))
            {
                return Directions.Right;
            }

            return Directions.Unknown;
        }
    }
}
