namespace GameSnake
{
    public class Speed
    {
        public const int ValueIncreaseSpeed = 25;

        private readonly int _startSpeed;
        private readonly int _speedUpInterval;

        private int _numberInterval = 0;

        public Speed(int speed = 100, int speedUpInterval = 5)
        {
            Value = _startSpeed = speed;
            _speedUpInterval = speedUpInterval;
        }

        public int Value { get; private set; }

        public void Increase(int score)
        {
            if (Value - ValueIncreaseSpeed > 0)
            {
                _numberInterval = score / _speedUpInterval;//Point interval number.
                Value = _startSpeed - _numberInterval * ValueIncreaseSpeed;
            }
        }

        public void Apply() => Thread.Sleep(Value);
    }
}
