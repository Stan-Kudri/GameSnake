using Core.Components;
using GameSnake.Enum;
using Microsoft.Xna.Framework.Input;

namespace MonoGameSnake.ComponentsGame
{
    public class UserInputMono : UserInput
    {
        private static readonly DirectionDetail[] _directionDetails = new[]
        {
            new DirectionDetail(Keys.Up, Directions.Up),
            new DirectionDetail(Keys.Down, Directions.Down),
            new DirectionDetail(Keys.Left, Directions.Left),
            new DirectionDetail(Keys.Right, Directions.Right),
        };

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

        private static Directions ToDirection(KeyboardState key)
        {
            foreach (var directionDetail in _directionDetails)
            {
                if (key.IsKeyDown(directionDetail.key))
                {
                    return directionDetail.directions;
                }
            }

            return Directions.Unknown;
        }

        private record DirectionDetail(Keys key, Directions directions);
    }
}
