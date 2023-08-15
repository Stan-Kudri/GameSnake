using Core.Components;

namespace GameSnake.ComponentsGame
{
    public class SpeedConsole : Speed
    {
        public SpeedConsole()
            : this(DefaultDecreaseSleepTime)
        {
        }

        public SpeedConsole(TimeSpan decreaseSleepTime, int numberOfScoreToBoos = DefaultNumberOfScoreToBoos)
            : base(decreaseSleepTime, numberOfScoreToBoos)
        {
        }

        public override bool Update(TimeSpan elapsedGameTime)
        {
            Thread.Sleep(SleepTime);
            return true;
        }
    }
}
