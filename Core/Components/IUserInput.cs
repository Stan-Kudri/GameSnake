using GameSnake.Enum;

namespace Core.Components
{
    public interface IUserInput
    {
        public event Action<IUserInput>? OnChangedDirection;

        public Directions CurrentDirection { get; }

        public void UpDate();
    }
}
