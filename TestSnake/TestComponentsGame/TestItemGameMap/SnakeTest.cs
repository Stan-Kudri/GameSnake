using Core;
using GameSnake.ComponentsGame.ItemGameMap;

namespace TestSnake.TestComponentsGame.TestItemGameMap
{
    public class SnakeTest
    {
        public static IEnumerable<object[]> TrueSnakePattern()
        {
            var border = new BorderConsole(20, 20);
            var startPositionX = border.Width / 2;
            var startPositionY = border.Height / 2;
            var length = 5;

            yield return new object[]
            {
                new SnakeConsole(startPositionX, startPositionY, border, length)
            };
        }

        [Theory]
        [InlineData(20, 20, 10, 10, 5, 15, 10)]
        [InlineData(10, 10, 3, 3, 2, 5, 3)]
        public void Move_Snake_At_New_Position(int width, int height, int startPositionX, int startPositionY, int countMoveSnakeByX, int expectHeadPositionX, int expectHeadPositionY)
        {
            //Arrange
            var border = new BorderConsole(width, height);
            var snake = new SnakeConsole(startPositionX, startPositionY, border);

            //Act
            var expectHeadPosition = new Points(expectHeadPositionX, expectHeadPositionY);
            for (var i = 0; i < countMoveSnakeByX; i++)
            {
                snake.Move();
            }
            var actualHeadPosition = snake.Head;

            //Assert
            Assert.Equal(expectHeadPosition, actualHeadPosition);
        }

        [Theory]
        [InlineData(20, 20, 10, 10, 10)]
        [InlineData(5, 5, 2, 2, 3)]
        public void Wall_Collision_While_Moving(int width, int height, int startPositionX, int startPositionY, int countMoveSnakeToCollision)
        {
            //Arrange
            var border = new BorderConsole(width, height);
            var snake = new SnakeConsole(startPositionX, startPositionY, border);

            //Act
            for (var i = 0; i < countMoveSnakeToCollision; i++)
            {
                snake.Move();
            }
            var result = snake.ObstacleCollision();

            //Assert
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(TrueSnakePattern))]
        public void Snake_Eat_Food(SnakeConsole snake)
        {
            //Arrange
            var expectFoodPosition = snake.Head;

            //Act
            var result = snake.TryEatFood(expectFoodPosition);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(TrueSnakePattern))]
        public void Equals_Position_Food_And_Snake(SnakeConsole snake)
        {
            //Arrange
            var expectFoodPosition = snake.Head;

            //Act
            var result = snake.IntersectBody(expectFoodPosition);

            //Assert
            Assert.True(result);
        }
    }
}
