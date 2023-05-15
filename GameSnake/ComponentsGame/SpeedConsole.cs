using Core.Components;

namespace GameSnake.ComponentsGame
{
    public class SpeedConsole : Speed
    {
        public SpeedConsole()
            : this(TimeSpan.FromMilliseconds(50), 5)
        {
        }

        public SpeedConsole(TimeSpan increaseSpeed, int thresholdPoints = 5)
            : base(increaseSpeed, thresholdPoints)
        {
        }

        public void Apply() => Thread.Sleep(ValueThreshold);
    }
}
