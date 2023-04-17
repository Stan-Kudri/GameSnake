using Core.Components;

namespace GameSnake.ComponentsGame
{
    public class SpeedConsole : Speed
    {
        public SpeedConsole(int speed = 20, int thresholdPoints = 5, int valueIncreaseSpeed = 20, int maxSpeed = 100)
            : base(speed, thresholdPoints, valueIncreaseSpeed, maxSpeed)
        {
        }

        public override void Apply() => Thread.Sleep(_maxSpeed - Value);
    }
}
