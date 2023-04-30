using System;
using Core.Components;

namespace MonoGameSnake.ComponentsGame
{
    public class SpeedMono : Speed
    {
        public SpeedMono(int speed = 20, int thresholdPoints = 5, int valueIncreaseSpeed = 20, int maxSpeed = 100)
            : base(speed, thresholdPoints, valueIncreaseSpeed, maxSpeed)
        {
        }

        public override void Apply()
        {
            throw new NotImplementedException();
        }
    }
}
