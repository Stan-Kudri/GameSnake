namespace Core.Components.GameMapItems.Foods
{
    public abstract class Food
    {
        public Food(Point position, int scorePoint = 1)
        {
            Score = scorePoint <= 0
                            ? throw new ArgumentException("Points for food are greater than zero.", nameof(scorePoint))
                            : scorePoint;
            Position = position;
        }

        public Point Position { get; private set; }

        public int Score { get; private set; }

        public abstract void Draw();
    }
}
