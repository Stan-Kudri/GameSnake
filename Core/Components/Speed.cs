namespace Core.Components
{
    public abstract class Speed
    {
        protected readonly TimeSpan LimitThreshold = TimeSpan.FromMilliseconds(100);
        protected readonly TimeSpan HalfSecond = TimeSpan.FromMilliseconds(500);

        protected readonly TimeSpan _startThreshold;
        protected readonly TimeSpan _increaseSpeed;
        protected readonly int _thresholdPoints;

        protected int _numberInterval = 0;
        protected TimeSpan _valueThreshold;

        public Speed(int thresholdPoints = 5)
            : this(TimeSpan.FromMilliseconds(50), thresholdPoints)
        {
        }

        public Speed(TimeSpan increaseSpeed, int thresholdPoints = 5)
        {
            _valueThreshold = _startThreshold = HalfSecond;

            if (thresholdPoints <= 0)
            {
                throw new ArgumentException("Interval points greater than zero.", nameof(thresholdPoints));
            }

            if (increaseSpeed.Milliseconds <= 0 || _valueThreshold <= increaseSpeed)
            {
                throw new ArgumentException("Increase speed greater than zero.", nameof(increaseSpeed));
            }

            _thresholdPoints = thresholdPoints;
            _increaseSpeed = increaseSpeed;
        }

        public TimeSpan ValueThreshold => _valueThreshold;

        public void Increase(int score)
        {
            _numberInterval = score / _thresholdPoints;

            var newThresholdMillisecond = _startThreshold - _numberInterval * _increaseSpeed;

            if (newThresholdMillisecond >= LimitThreshold)
            {
                // Point interval number.
                _valueThreshold = newThresholdMillisecond;
            }
        }
    }
}
