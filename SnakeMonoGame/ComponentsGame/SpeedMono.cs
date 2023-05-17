using System;
using Core.Components;
using Microsoft.Xna.Framework;

namespace MonoGameSnake.ComponentsGame
{
    public class SpeedMono : Speed
    {
        private TimeSpan _currentTimeMove = TimeSpan.Zero; // The amount of elapsed time.
        private TimeSpan _currentTimeButton = TimeSpan.Zero; // Time from button press.

        public SpeedMono()
            : base(TimeSpan.FromMilliseconds(50), 5)
        {
        }

        public event Action OnPressButton;

        public event Action OnTimeMovie;

        private TimeSpan TimePressButton => ValueThreshold.Divide(3);

        public void Update(GameTime gameTime)
        {
            _currentTimeButton += gameTime.ElapsedGameTime;
            _currentTimeMove += gameTime.ElapsedGameTime;

            if (_currentTimeButton >= TimePressButton)
            {
                _currentTimeButton = TimeSpan.Zero;
                OnPressButton?.Invoke();
            }

            if (_currentTimeMove >= ValueThreshold)
            {
                _currentTimeMove -= ValueThreshold;
                OnTimeMovie?.Invoke();
            }
        }
    }
}
