using Core.Components;

namespace MonoGameSnake.ComponentsGame
{
    public class SpeedMono : Speed
    {
        public SpeedMono(int thresholdPoints = 5, int increaseSpeedMillisecond = 100)
            : base(thresholdPoints, increaseSpeedMillisecond)
        {
        }

        public int TimePressButton => ValueThresholdMillisecond / 3;
    }
}
