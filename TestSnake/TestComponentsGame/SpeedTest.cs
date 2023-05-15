using GameSnake.ComponentsGame;

namespace TestSnake.TestComponentsGame
{
    public class SpeedTest
    {
        [Theory]
        [InlineData(5, 100, 6, 400)]
        [InlineData(5, 100, 12, 300)]
        public void Speed_Up(int thresholdPoints, int increaseSpeedMillisecond, int score, int expectValueThreshold)
        {
            //Arrange
            var timeSpanMillisecond = TimeSpan.FromMilliseconds(increaseSpeedMillisecond);
            var timeSpanExpect = TimeSpan.FromMilliseconds(expectValueThreshold);
            var speedSnake = new SpeedConsole(timeSpanMillisecond, thresholdPoints);

            //Act
            speedSnake.Increase(score);
            var actualSpeed = speedSnake.ValueThreshold;

            //Assert
            Assert.Equal(timeSpanExpect, actualSpeed);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2000)]
        [InlineData(-20)]
        public void Exception_The_Speed_Constructor_By_Zero(int increaseSpeedMillisecond)
        {
            var timeSpan = TimeSpan.FromMilliseconds(increaseSpeedMillisecond);
            Assert.Throws<ArgumentException>(() => { new SpeedConsole(timeSpan, 5); });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void Exception_The_Threshold_Points_Constructor_By_Zero(int thresholdPoints)
        {
            var timeSpan = TimeSpan.FromMicroseconds(10);
            Assert.Throws<ArgumentException>(() => { new SpeedConsole(timeSpan, thresholdPoints); });
        }

    }
}
