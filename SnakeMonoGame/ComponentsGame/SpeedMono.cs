using System;
using Core.Components;

namespace MonoGameSnake.ComponentsGame
{
    public class SpeedMono : Speed
    {
        private readonly int _buttonPressPeriod = 200;
        private readonly int _periodToRefreshMovement;

        public SpeedMono(int speed = 20, int thresholdPoints = 5, int valueIncreaseSpeed = 20, int maxSpeed = 100, int period = 5000)
            : base(speed, thresholdPoints, valueIncreaseSpeed, maxSpeed)
        {
            if (period <= 100)
            {
                throw new ArgumentException("Period value is incorrect.", nameof(period));
            }

            _periodToRefreshMovement = period;
        }

        public int TimeMove => _periodToRefreshMovement / Value;

        public int TimePressButton => _buttonPressPeriod / (_numberInterval + 1);
    }
}
