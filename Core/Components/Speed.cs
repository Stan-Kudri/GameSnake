namespace Core.Components
{
    public abstract class Speed
    {
        protected const int LimitThresholdMillisecond = 100;
        protected const int OneSecondToMilliseconds = 500;

        protected readonly int _startThresholdMillisecond;
        protected readonly int _thresholdPoints;
        protected readonly int _increaseSpeedMillisecond;
        protected readonly int _maxSpeed;

        protected int _numberInterval = 0;

        public Speed(int thresholdPoints = 5, int increaseSpeedMillisecond = 50)
        {
            ValueThresholdMillisecond = _startThresholdMillisecond = OneSecondToMilliseconds;

            if (thresholdPoints <= 0)
            {
                throw new ArgumentException("Interval points greater than zero.", nameof(thresholdPoints));
            }

            if (increaseSpeedMillisecond <= 0 || ValueThresholdMillisecond <= increaseSpeedMillisecond)
            {
                throw new ArgumentException("Increase speed greater than zero.", nameof(increaseSpeedMillisecond));
            }

            _thresholdPoints = thresholdPoints;
            _increaseSpeedMillisecond = increaseSpeedMillisecond;
        }

        public int ValueThresholdMillisecond { get; private set; }

        public void Increase(int score)
        {
            _numberInterval = score / _thresholdPoints;

            var newThresholdMillisecond = _startThresholdMillisecond - _numberInterval * _increaseSpeedMillisecond;

            if (newThresholdMillisecond >= LimitThresholdMillisecond)
            {
                // Point interval number.
                ValueThresholdMillisecond = newThresholdMillisecond;
            }
        }
    }
}
