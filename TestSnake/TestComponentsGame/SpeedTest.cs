using GameSnake.ComponentsGame;

namespace TestSnake.TestComponentsGame
{
    public class SpeedTest
    {
        [Theory]
        [InlineData(20, 5, 20, 100, 13, 60)]
        [InlineData(20, 5, 20, 100, 18, 80)]
        public void Speed_Up(int speed, int thresholdPoints, int valueIncreaseSpeed, int maxSpeed, int score, int expectSpeed)
        {
            //Arrange
            var speedSnake = new SpeedConsole(speed, thresholdPoints, valueIncreaseSpeed, maxSpeed);

            //Act
            speedSnake.Increase(score);
            var actualSpeed = speedSnake.Value;

            //Assert
            Assert.Equal(expectSpeed, actualSpeed);
        }

        [Theory]
        [InlineData(0)]
        public void Exception_The_Speed_Constructor_By_Zero(int speed)
        {
            Assert.Throws<ArgumentException>(() => { new SpeedConsole(speed); });
        }

        [Theory]
        [InlineData(0)]
        public void Exception_The_Threshold_Points_Constructor_By_Zero(int threshold)
        {
            Assert.Throws<ArgumentException>(() => { new SpeedConsole(100, threshold); });
        }

    }
}
