using GameSnake.Components;
using GameSnake.Components.ItemGameMap;
using GameSnake.ComponentsGame.ItemGameMap;

namespace TestSnake.TestComponentsGame
{
    public class GameMapTest
    {
        public static IEnumerable<object[]> ClassInstances()
        {
            var border = new Border(20, 10);
            var snake = new Snake(10, 10, border, 2);

            yield return new object[]
            {
                new GameMap(border, snake)
            };
        }

        public static IEnumerable<object[]> ClassNotEmptyPosition()
        {
            var border = new Border(3, 3);
            var snake = new Snake(1, 1, border, 1);

            yield return new object[]
            {
                new GameMap(border, snake)
            };

        }

        [Theory]
        [MemberData(nameof(ClassInstances))]
        public void Move_Item_Game_Map(GameMap gameMap)
        {
            //Act
            for (var i = 0; i > 9; i++)
            {
                gameMap.Move();
            }

            //Assert
            Assert.True(gameMap.GameOver());
        }

        [Theory]
        [InlineData()]
        public void No_Food_Cell()
        {
            //Act
            var border = new Border(2, 2);
            var snake = new Snake(1, 1, border, 1);

            //Assert
            Assert.Throws<Exception>(() => { new GameMap(border, snake); });
        }
    }
}
