using System;
using Core.Components;

namespace MonoGameSnake.ComponentsGame
{
    public class SpeedMono : Speed
    {
        public SpeedMono()
            : base(TimeSpan.FromMilliseconds(50), 5)
        {
        }

        public TimeSpan TimePressButton => ValueThreshold.Divide(3);
    }
}
