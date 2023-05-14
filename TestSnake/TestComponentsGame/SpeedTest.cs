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
            var speedSnake = new SpeedConsole(thresholdPoints, increaseSpeedMillisecond);

            //Act
            speedSnake.Increase(score);
            var actualSpeed = speedSnake.ValueThresholdMillisecond;

            //Assert
            Assert.Equal(expectValueThreshold, actualSpeed);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2000)]
        [InlineData(-20)]
        public void Exception_The_Speed_Constructor_By_Zero(int increaseSpeedMillisecond)
        {
            Assert.Throws<ArgumentException>(() => { new SpeedConsole(5, increaseSpeedMillisecond); });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void Exception_The_Threshold_Points_Constructor_By_Zero(int thresholdPoints)
        {
            Assert.Throws<ArgumentException>(() => { new SpeedConsole(thresholdPoints, 100); });
        }

    }
}
