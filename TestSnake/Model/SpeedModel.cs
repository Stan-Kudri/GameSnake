using Core.Components;

namespace TestSnake.Model
{
    public class SpeedModel : Speed
    {
        public SpeedModel(TimeSpan decreaseSleepTime, int numberOfScoreToBoos = DefaultNumberOfScoreToBoos)
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
