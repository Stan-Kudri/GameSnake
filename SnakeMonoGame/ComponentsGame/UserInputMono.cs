using Core.Components;
using GameSnake.Enum;
using Microsoft.Xna.Framework.Input;
using SnakeMonoGame.Extension;

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
            var direction = keyBoard.ToDirection();
            ChangeDirection(direction);
        }
    }
}
