using GameSnake;
using GameSnake.Components;
using GameSnake.Components.ItemGameMap;

namespace TestSnake
{
    public class ScoreTest
    {
        public static IEnumerable<object[]> ItemScore()
        {
            yield return new object[]
            {
                new Score(10, 0),
                20,
                20,
            };
        }

        [Theory]
        [MemberData(nameof(ItemScore))]
        public void Add_Points_To_Score(Score score, int points, int expectScore)
        {
            //Actual
            var positionFood = new Point(2, 2);
            var food = new Food(positionFood, points);

            //Act
            score.Increase(food);
            var actualScore = score.Points;

            //Assert
            Assert.Equal(expectScore, actualScore);
        }

        [Theory]
        [InlineData(-20)]
        public void Exception_The_Points_Constructor_By_Negative_Value(int points)
        {
            Assert.Throws<ArgumentException>(() => { new Score(10, points); });
        }
    }
}
