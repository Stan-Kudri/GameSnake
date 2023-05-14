namespace Core.Components.GameMapItems.Foods
{
    public abstract class Food
    {
        public Food(Points position, int scorePoint = 1)
        {
            if (scorePoint <= 0)
            {
                throw new ArgumentException("Points for food are greater than zero.", nameof(scorePoint));
            }

            Position = position;
            Score = scorePoint;
        }

        public Points Position { get; private set; }

        public int Score { get; private set; }

        public abstract void Draw();
    }
}
