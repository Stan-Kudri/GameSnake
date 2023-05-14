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
            var centerOfX = _border.Width / 2;
            var centerOfY = _border.Height / 2;
            var centerOfMessage = Message.Length / 2;
            _startWidthMessage = centerOfX - centerOfMessage;
            _startHeightMessage = centerOfY;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(_startWidthMessage, _startHeightMessage);
            Console.WriteLine(Message);
        }
    }
}
