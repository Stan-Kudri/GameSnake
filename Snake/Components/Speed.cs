namespace GameSnake
{
    public class Speed
    {
        public const int ValueIncreaseSpeed = 20;

        public Speed(int speed = 100)
        {
            Value = speed;
        }

        public int Value { get; private set; }

        public void Increase() => Value = Value - ValueIncreaseSpeed > 0 ? Value - ValueIncreaseSpeed : Value;
    }
}
