namespace Core.Games
{
    public abstract class GameFactory
    {
        public abstract Game Create(
            int width, int height, int snakeLength);
    }
}
