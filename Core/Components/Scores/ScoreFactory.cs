namespace Core.Components.Scores
{
    public abstract class ScoreFactory
    {
        public abstract Score Create(int height, int points = 0);
    }
}
