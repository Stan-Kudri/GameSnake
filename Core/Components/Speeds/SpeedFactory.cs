namespace Core.Components.Speeds
{
    public abstract class SpeedFactory
    {
        public abstract Speed Create(int speed, int thresholdPoints, int valueIncreaseSpeed, int maxSpeed);
    }
}
