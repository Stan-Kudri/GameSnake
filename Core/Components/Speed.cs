namespace Core.Components
{
    public abstract class Speed
    {
        protected const int DefaultNumberOfScoreToBoos = 5;

        protected readonly TimeSpan MinSleepTime = TimeSpan.FromMilliseconds(100);

        private readonly TimeSpan _initialSleepTime;
        private readonly TimeSpan _decreaseSleepTime;
        private readonly int _numberOfScoreToBoost;

        private TimeSpan _sleepTime;

        public Speed(int numberOfScoreToBoos = DefaultNumberOfScoreToBoos)
            : this(DefaultDecreaseSleepTime, numberOfScoreToBoos)
        {
        }

        public Speed(TimeSpan decreaseSleepTime, int numberOfScoreToBoos = DefaultNumberOfScoreToBoos)
        {
            var halfSecond = TimeSpan.FromMilliseconds(500);
            _sleepTime = _initialSleepTime = halfSecond;

            if (numberOfScoreToBoos <= 0)
            {
                throw new ArgumentException("Interval points greater than zero.", nameof(numberOfScoreToBoos));
            }

            if (decreaseSleepTime.Milliseconds <= 0 || _sleepTime <= decreaseSleepTime)
            {
                throw new ArgumentException("Increase speed greater than zero.", nameof(decreaseSleepTime));
            }

            _numberOfScoreToBoost = numberOfScoreToBoos;
            _decreaseSleepTime = decreaseSleepTime;
        }

        public TimeSpan SleepTime => _sleepTime;

        protected static TimeSpan DefaultDecreaseSleepTime => TimeSpan.FromMilliseconds(50);

        public void Increase(int score)
        {
            var accelerationFactor = score / _numberOfScoreToBoost;
            var decreaseSleepTime = accelerationFactor * _decreaseSleepTime;
            var newSleepTime = _initialSleepTime - decreaseSleepTime;

            if (newSleepTime >= MinSleepTime)
            {
                // Point interval number.
                _sleepTime = newSleepTime;
            }
        }
    }
}
