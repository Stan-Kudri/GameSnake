using System.Drawing;

namespace TestSnake
{
    public class PointTest
    {
        [Theory]
        [InlineData(5, 10)]
        [InlineData(2, 40)]
        [InlineData(3, 5)]
        public void Not_Equals_Point(int firstPosition, int secondPosition)
        {
            //Arrange
            var firstPoint = new Point(firstPosition, secondPosition);
            var secondPoint = new Point(secondPosition, firstPosition);

            //Assert
            Assert.NotEqual(firstPoint, secondPoint);
        }

        [Theory]
        [InlineData(5, 10)]
        [InlineData(2, 40)]
        [InlineData(3, 5)]
        public void Equals_Point(int firstPosition, int secondPosition)
        {
            //Arrange
            var firstPoint = new Point(firstPosition, secondPosition);
            var secondPoint = new Point(firstPosition, secondPosition);

            //Assert
            Assert.Equal(firstPoint, secondPoint);
        }
    }
}