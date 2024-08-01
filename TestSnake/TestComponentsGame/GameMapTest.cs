using Core.Components;
using TestSnake.Model;
using TestSnake.Model.ItemsGameMap;

namespace TestSnake.TestComponentsGame
{
    public class GameMapTest
    {
        [Theory]
        [InlineData(20, 20)]
        public void Move_Item_Game_Map_To_Game_Over(int width, int height)
        {
            // Arrange
            var borederSize = new BorderSize(width, height);
            var border = new BorderModel(borederSize);
            var snake = new SnakeModel(border);
            var snakePositionHead = snake.Body.Last().X;
            var gameMap = new GameMapModel(border, snake);

            // Act
            for (var i = snakePositionHead; i <= width + 1; i++)
            {
                gameMap.Move();
            }

            // Assert
            Assert.True(gameMap.IsGameOver());
        }

        [Theory]
        [InlineData(3, 3)]
        public void No_Food_Cell(int width, int height)
        {
            // Arrange
            var borederSize = new BorderSize(width, height);
            var border = new BorderModel(borederSize);
            var snake = new SnakeModel(border);

            // Assert
            Assert.Throws<Exception>(() => { new GameMapModel(border, snake); });
        }
    }
}
