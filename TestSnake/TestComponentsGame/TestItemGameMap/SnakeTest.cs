using GameSnake;
using GameSnake.Components.ItemGameMap;
using GameSnake.ComponentsGame.ItemGameMap;

namespace TestSnake.TestComponentsGame.TestItemGameMap
{
    public class SnakeTest
    {
        public static IEnumerable<object[]> TrueSnakePattern()
        {
            var border = new Border(20, 20);
            var startPositionX = border.Width / 2;
            var startPositionY = border.Height / 2;
            var length = 5;

            yield return new object[]
            {
                new Snake(startPositionX, startPositionY, border, length)
            };
        }

        [Theory]
        [InlineData(20, 20, 5)]
        public void Move_Snake_At_New_Position(int width, int height, int countMoveSnakeByX)
        {
            //Arrange
            var border = new Border(width, height);
            var startPositionX = border.Width / 2;
            var startPositionY = border.Height / 2;
            var length = 1;
            var snake = new Snake(startPositionX, startPositionY, border, length);

            //Act
            var expectHeadPosition = new Point(snake.Head.X + countMoveSnakeByX, snake.Head.Y);
            for (var i = 0; i < countMoveSnakeByX; i++)
            {
                snake.Move();
            }
            var actualHeadPosition = snake.Head;

            //Assert
            Assert.Equal(expectHeadPosition, actualHeadPosition);
        }

        [Theory]
        [InlineData(20, 20)]
        public void Wall_Collision_While_Moving(int width, int height)
        {
            //Arrange
            var border = new Border(width, height);
            var startPositionX = border.Width / 2;
            var startPositionY = border.Height / 2;
            var length = 1;
            var snake = new Snake(startPositionX, startPositionY, border, length);

            //Act
            var countMoveSnakeToCollision = border.Width - startPositionX;
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
        public void Snake_Eat_Food(Snake snake)
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
        public void Equals_Position_Food_And_Snake(Snake snake)
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
