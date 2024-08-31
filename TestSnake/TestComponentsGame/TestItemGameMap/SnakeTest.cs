using Core.Components;
using TestSnake.Model.ItemsGameMap;

namespace TestSnake.TestComponentsGame.TestItemGameMap
{
    public class SnakeTest
    {
        public static IEnumerable<object[]> TrueSnakePattern()
        {
            var borderSize = new BorderSize(20, 20);
            var border = new BorderModel(borderSize);

            yield return new object[]
            {
                new SnakeModel(border),
            };
        }

        [Theory]
        [InlineData(20, 20)]
        [InlineData(10, 10)]
        public void Wall_Collision_While_Moving(int width, int height)
        {
            // Arrange
            var borderSize = new BorderSize(width, height);
            var border = new BorderModel(borderSize);
            var snake = new SnakeModel(border);
            var countMoveSnakeToCollision = snake.Body.Last().X;

            // Act
            for (var i = 0; i <= countMoveSnakeToCollision + 1; i++)
            {
                snake.Move();
            }

            var result = snake.ObstacleCollision();

            // Assert
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(TrueSnakePattern))]
        public void Snake_Eat_Food(SnakeModel snake)
        {
            // Arrange
            var expectFoodPosition = snake.Head;

            // Act
            var result = snake.TryEatFood(expectFoodPosition);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(TrueSnakePattern))]
        public void Equals_Position_Food_And_Snake(SnakeModel snake)
        {
            // Arrange
            var expectFoodPosition = snake.Head;

            // Act
            var result = snake.IntersectBody(expectFoodPosition);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(3, 3)]
        public void Too_Long_Snake_For_Border(int width, int height)
        {
            // Arrange
            var borederSize = new BorderSize(width, height);
            var border = new BorderModel(borederSize);

            // Assert
            Assert.Throws<ArgumentException>(() => { new SnakeModel(border); });
        }
    }
}
