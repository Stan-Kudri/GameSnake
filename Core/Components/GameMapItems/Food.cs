namespace Core.Components.GameMapItems
{
    public class Food
    {
        public Food(Point position, int scorePoint = 1)
        {
            if (scorePoint <= 0)
            {
                throw new ArgumentException("Points for food are greater than zero.", nameof(scorePoint));
            }

            Position = position;
            Score = scorePoint;
        }

        public Point Position { get; private set; }

        public int Score { get; private set; }
    }
}
