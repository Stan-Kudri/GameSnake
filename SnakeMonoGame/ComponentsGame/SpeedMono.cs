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

        private TimeSpan TimePressButton => _valueThreshold.Divide(3);

        public void Update(GameTime gameTime)
        {
            _currentTimeButton += gameTime.ElapsedGameTime;
            _currentTimeMove += gameTime.ElapsedGameTime;
        }

        public bool CanPressButton()
        {
            if (_currentTimeButton >= TimePressButton)
            {
                _currentTimeButton = TimeSpan.Zero;
                return true;
            }

            return false;
        }

        public bool CanTimeMovie()
        {
            if (_currentTimeMove >= _valueThreshold)
            {
                _currentTimeMove -= _valueThreshold;
                return true;
            }

            return false;
        }
    }
}
