using Core.Components;
using Core.Components.GameMapItems;

namespace GameSnake.ComponentsGame
{
    public class GameOverConsole : GameOver
    {
        private const string Message = "Game Over";

        private readonly int _startWidthMessage;
        private readonly int _startHeightMessage;

        public GameOverConsole(Border border)
            : base(border)
        {
            _startWidthMessage = (_border.Width / 2) - (Message.Length / 2);
            _startHeightMessage = _border.Height / 2;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(_startWidthMessage, _startHeightMessage);
            Console.WriteLine(Message);
        }
    }
}
