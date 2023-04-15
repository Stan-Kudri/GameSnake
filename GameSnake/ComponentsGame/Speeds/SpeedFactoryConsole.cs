using Core.Components.Speeds;

namespace GameSnake.ComponentsGame.Speeds
{
    public class SpeedFactoryConsole : SpeedFactory
    {
        public override SpeedConsole Create(int speed, int thresholdPoints, int valueIncreaseSpeed, int maxSpeed)
            => new SpeedConsole(speed, thresholdPoints, valueIncreaseSpeed, maxSpeed);
    }
}
