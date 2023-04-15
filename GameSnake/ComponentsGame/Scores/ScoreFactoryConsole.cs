using Core.Components.Scores;

namespace GameSnake.ComponentsGame.Scores
{
    public class ScoreFactoryConsole : ScoreFactory
    {
        public override ScoreConsole Create(int height, int points) => new ScoreConsole(height, points);
    }
}
