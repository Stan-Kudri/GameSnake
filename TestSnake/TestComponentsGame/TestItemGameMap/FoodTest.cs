using Core;
using GameSnake.ComponentsGame.ItemGameMap;

namespace TestSnake.TestComponentsGame.TestItemGameMap
{
    public class FoodTest
    {
        [Theory]
        [InlineData(-20)]
        public void Exception_When_Transferring_Points_Less_Than_Zero(int points)
        {
            Assert.Throws<ArgumentException>(() => { new FoodConsole(new Point(2, 2), points); });
        }
    }
}
