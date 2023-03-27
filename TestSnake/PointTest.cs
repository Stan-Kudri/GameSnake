using System.Drawing;

namespace TestSnake
{
    public class PointTest
    {
        public static IEnumerable<object[]> TwoPoints() => new List<object[]>
            {
                new object[]
                {
                    new List<Point>()
                    {
                        new Point(5,1),
                        new Point(1,5)
                    },
                },
            };

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