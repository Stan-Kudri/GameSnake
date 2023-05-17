using System;
using Core.Components;
using Microsoft.Xna.Framework;

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

        public event Action OnTimeMovie;

        public void Update(GameTime gameTime)
        {
            _currentTimeMove += gameTime.ElapsedGameTime;

            if (_currentTimeMove >= SleepTime)
            {
                _currentTimeMove -= SleepTime;
                OnTimeMovie?.Invoke();
            }
        }
    }
}
