using GameSnake.Components.ItemGameMap;

namespace TestSnake.TestComponentsGame.TestItemGameMap
{
    public class BorderTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-5, 23)]
        public void Exception_When_Create_Borders_In_Game_Map(int width, int height)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => { new Border(width, height); });
        }
    }
}
