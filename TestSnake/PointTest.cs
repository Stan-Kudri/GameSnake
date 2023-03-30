using System.Drawing;

namespace TestSnake
{
    public class PointTest
    {
        public static IEnumerable<object[]> TwoPoints()
        {
            var positionX = 5;
            var positionY = 1;

            yield return new object[]
            {
                new List<Point>()
                {
                    new Point(positionX, positionY),
                    new Point(positionY, positionX)
                },
            };
        }

        [Theory]
        [MemberData(nameof(TwoPoints))]
        public void Not_Equals_Point(List<Point> points)
        {
            Assert.NotEqual(points[0], points[1]);
        }

        [Theory]
        [MemberData(nameof(TwoPoints))]
        public void Equals_Point(List<Point> points)
        {
            Assert.Equal(points[0], points[0]);
            Assert.Equal(points[1], points[1]);
        }
    }
}