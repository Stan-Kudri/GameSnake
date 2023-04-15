using GameSnake.Enum;

namespace Core.Components.UserInputs
{
    public abstract class UserInputFactory
    {
        public abstract IUserInput Create();

        public abstract IUserInput Create(Directions directions);
    }
}
