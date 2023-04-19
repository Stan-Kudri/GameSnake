using Core.Components;

namespace GameSnake.ComponentsGame
{
    public class ScoreConsole : Score
    {
        public ScoreConsole(int height, int points = 0)
            : base(height, points)
        {
        }

        public override void Draw()
        {
            var scoreLine = $"Score : {Points}";

            Console.SetCursorPosition(0, _startHeightDisplay);
            Console.Write(scoreLine);
        }
    }
}
