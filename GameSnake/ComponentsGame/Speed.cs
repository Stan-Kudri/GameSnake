namespace GameSnake
{
    public class Speed
    {
        private readonly int _startSpeed;
        private readonly int _thresholdPoints;
        private readonly int _valueIncreaseSpeed;

        private int _numberInterval = 0;

        public Speed(int speed = 100, int thresholdPoints = 5, int valueIncreaseSpeed = 25)
        {
            if (speed <= 0)
            {
                throw new ArgumentException("Speed greater than zero.", nameof(speed));
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
            _thresholdPoints = thresholdPoints;
            _valueIncreaseSpeed = valueIncreaseSpeed;
        }

        public int Value { get; private set; }

        public void Increase(int score)
        {
            if (Value - _valueIncreaseSpeed > 0)
            {
                //Point interval number.
                _numberInterval = score / _thresholdPoints;
                Value = _startSpeed - _numberInterval * _valueIncreaseSpeed;
            }
        }

        public void Apply() => Thread.Sleep(Value);
    }
}
