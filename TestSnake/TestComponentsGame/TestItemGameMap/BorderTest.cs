using Core.Components;

namespace TestSnake.TestComponentsGame.TestItemGameMap
{
    public class BorderTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-5, 23)]
        public void Exception_When_Create_Border_Size_In_Game_Map(int width, int height)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => { new BorderSize(width, height); });
        }
    }
}
