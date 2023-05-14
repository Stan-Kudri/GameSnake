using Core.Components;

namespace GameSnake.ComponentsGame
{
    public class SpeedConsole : Speed
    {
        public SpeedConsole(int thresholdPoints = 5, int increaseSpeedMillisecond = 100)
            : base(thresholdPoints, increaseSpeedMillisecond)
        {
        }

        public void Apply() => Thread.Sleep(ValueThresholdMillisecond);
    }
}
