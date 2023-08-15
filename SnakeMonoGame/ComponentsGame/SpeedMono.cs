using System;
using Core.Components;

namespace MonoGameSnake.ComponentsGame
{
    public class SpeedMono : Speed
    {
        // The amount of elapsed time.
        private TimeSpan _currentTimeMove = TimeSpan.Zero;

        public SpeedMono()
            : base(DefaultDecreaseSleepTime)
        {
        }

        public override bool Update(TimeSpan elapsedGameTime)
        {
            _currentTimeMove += elapsedGameTime;

            if (_currentTimeMove < SleepTime)
            {
                return false;
            }

            _currentTimeMove -= SleepTime;
            return true;
        }
    }
}
