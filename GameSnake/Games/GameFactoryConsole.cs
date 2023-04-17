using Core.Games;
using GameSnake.ComponentsGame;
using GameSnake.ComponentsGame.GameMaps;
using GameSnake.ComponentsGame.ItemGameMap;
using GameSnake.ComponentsGame.ItemGameMap.Foods;
using GameSnake.Extension;

namespace GameSnake.Games
{
    public class GameFactoryConsole : GameFactory
    {
        public override Game Create(
            int width, int height, int snakeLength = 5)
        {
            var userInput = new UserInput();
            var scoreConsole = new ScoreConsole(height);
            var speedConsole = new SpeedConsole();

            var borderConsole = new BorderConsole(width, height);
            var snakeConsole = borderConsole.Creator(snakeLength);
            var foodFactoryConsole = new FoodFactoryConsole();

            var gameMapConsole = new GameMapConsole(borderConsole, snakeConsole, foodFactoryConsole);

            return new Game(
                userInput,
                scoreConsole,
                speedConsole,
                gameMapConsole);
        }
    }
}
