using Core.Games;
using GameSnake.ComponentsGame;
using GameSnake.ComponentsGame.GameMaps;
using GameSnake.ComponentsGame.ItemGameMap;
using GameSnake.ComponentsGame.ItemGameMap.Foods;
using GameSnake.ComponentsGame.ItemGameMap.Snakes;

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
            var borderCreate = new BorderConsole(width, height);
            var snakeFactoryConsole = new SnakeFactoryConsole();
            var foodFactoryConsole = new FoodFactoryConsole();
            var gameMapFactoryConsole = new GameMapFactoryConsole();

            return new Game(
                width,
                height,
                snakeLength,
                userInput,
                scoreConsole,
                speedConsole,
                borderCreate,
                snakeFactoryConsole,
                foodFactoryConsole,
                gameMapFactoryConsole);
        }
    }
}
