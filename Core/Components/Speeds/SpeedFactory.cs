namespace Core.Components.Speeds
{
    public abstract class SpeedFactory
    {
        public abstract Speed Create(int speed = 20, int thresholdPoints = 5, int valueIncreaseSpeed = 20, int maxSpeed = 100);
    }
}
