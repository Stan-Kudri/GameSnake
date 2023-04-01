using GameSnake;

namespace TestSnake.TestComponentsGame
{
    public class SpeedTest
    {
        [Theory]
        [InlineData(100, 5, 25, 13, 50)]
        public void Speed_Up(int speed, int thresholdPoints, int valueIncreaseSpeed, int score, int expectSpeed)
        {
            //Arrange
            var speedSnake = new Speed(speed, thresholdPoints, valueIncreaseSpeed);

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
            Assert.Throws<ArgumentException>(() => { new Speed(speed); });
        }

        [Theory]
        [InlineData(0)]
        public void Exception_The_Threshold_Points_Constructor_By_Zero(int threshold)
        {
            Assert.Throws<ArgumentException>(() => { new Speed(100, threshold); });
        }

    }
}
