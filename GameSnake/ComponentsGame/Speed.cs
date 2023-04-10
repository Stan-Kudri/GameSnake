namespace GameSnake.ComponentsGame
{
    public class Speed
    {
        private readonly int _startSpeed;
        private readonly int _thresholdPoints;
        private readonly int _valueIncreaseSpeed;
        private readonly int _maxSpeed;

        private int _numberInterval = 0;

        public Speed(int speed = 20, int thresholdPoints = 5, int valueIncreaseSpeed = 20, int maxSpeed = 100)
        {
            if (speed <= 0)
            {
                throw new ArgumentException("Speed greater than zero.", nameof(speed));
            }

            if (speed > maxSpeed)
            {
                throw new ArgumentException("The maximum speed is higher than the initial speed.", nameof(maxSpeed));
            }

            if (thresholdPoints <= 0)
            {
                throw new ArgumentException("Interval points greater than zero.", nameof(thresholdPoints));
            }

            if (thresholdPoints <= 0)
            {
                throw new ArgumentException("Increase speed greater than zero.", nameof(valueIncreaseSpeed));
            }

            Value = _startSpeed = speed;
            _maxSpeed = maxSpeed;
            _thresholdPoints = thresholdPoints;
            _valueIncreaseSpeed = valueIncreaseSpeed;
        }

        public int Value { get; private set; }

        public void Increase(int score)
        {
            if (_maxSpeed - Value - _valueIncreaseSpeed > 0)
            {
                // Point interval number.
                _numberInterval = score / _thresholdPoints;
                Value = _startSpeed + (_numberInterval * _valueIncreaseSpeed);
            }
        }

        public void Apply() => Thread.Sleep(_maxSpeed - Value);
    }
}
