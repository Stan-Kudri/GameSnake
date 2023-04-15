using Core.Components.UserInputs;
using GameSnake.Enum;

namespace GameSnake.ComponentsGame.UserInputs
{
    public class UserInputFactoryConsole : UserInputFactory
    {
        public override UserInput Create() => new UserInput();

        public override UserInput Create(Directions directions) => new UserInput(directions);
    }
}
