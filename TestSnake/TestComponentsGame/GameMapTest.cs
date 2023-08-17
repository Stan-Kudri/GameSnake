using Core.Components;
using GameSnake.ComponentsGame;
using GameSnake.ComponentsGame.ItemGameMap;

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
            var border = new BorderConsole(borederSize);
            var snake = new SnakeConsole(border);
            var snakePositionX = snake.Body.Last().X;
            var gameMap = new GameMapConsole(border, snake);

            // Act
            for (var i = snakePositionX; i <= width + 1; i++)
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
            var border = new BorderConsole(borederSize);
            var snake = new SnakeConsole(border);

            // Assert
            Assert.Throws<Exception>(() => { new GameMapConsole(border, snake); });
        }
    }
}
