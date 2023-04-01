using GameSnake;
using GameSnake.Components;
using GameSnake.Components.ItemGameMap;

namespace TestSnake.TestComponentsGame
{
    public class ScoreTest
    {
        [Theory]
        [InlineData(10, 10)]
        public void Add_Points_To_Score(int startHeightDisplay, int expectScore)
        {
            //Arrange
            var startScore = 0;
            var score = new Score(startHeightDisplay, startScore);
            var positionFood = new Point(2, 2);
            var food = new Food(positionFood, expectScore);

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
