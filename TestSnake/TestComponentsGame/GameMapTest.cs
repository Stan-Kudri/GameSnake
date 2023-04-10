using GameSnake.ComponentsGame;
using GameSnake.ComponentsGame.ItemGameMap;

namespace TestSnake.TestComponentsGame
{
    public class GameMapTest
    {
        [Theory]
        [InlineData(20, 20, 2)]
        public void Move_Item_Game_Map_To_Game_Over(int width, int height, int length)
        {
            //Arrange
            var border = new Border(width, height);
            var snakePositionX = width / 2;
            var snakePositionY = height / 2;
            var snake = new Snake(snakePositionX, snakePositionY, border, length);
            var gameMap = new GameMap(border, snake);

            //Act
            for (var i = snakePositionX; i < width - 1; i++)
            {
                gameMap.Move();
            }

            //Assert
            Assert.True(gameMap.IsGameOver());
        }

        [Theory]
        [InlineData(3, 3, 1, 1, 1)]
        public void No_Food_Cell(int width, int height, int snakePositionX, int snakePositionY, int length)
        {
            //Arrange
            var border = new Border(width, height);
            var snake = new Snake(snakePositionX, snakePositionY, border, length);

            //Assert
            Assert.Throws<Exception>(() => { new GameMap(border, snake); });
        }
    }
}