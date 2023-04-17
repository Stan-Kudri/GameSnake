using GameSnake.Games;

namespace TestSnake
{
    public class GameTest
    {
        [Theory]
        [InlineData(-5, 10, 2)]
        [InlineData(10, -2, 2)]
        [InlineData(10, 10, -2)]
        public void Exception_When_Create_Borders_In_Game_Map(int width, int height, int snakeLength)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => { new GameFactoryConsole().Create(width, height, snakeLength); });
        }
    }
}
