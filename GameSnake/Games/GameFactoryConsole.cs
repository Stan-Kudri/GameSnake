using Core.Games;
using GameSnake.ComponentsGame.GameMaps;
using GameSnake.ComponentsGame.ItemGameMap.Borders;
using GameSnake.ComponentsGame.ItemGameMap.Foods;
using GameSnake.ComponentsGame.ItemGameMap.Snakes;
using GameSnake.ComponentsGame.Scores;
using GameSnake.ComponentsGame.Speeds;
using GameSnake.ComponentsGame.UserInputs;

namespace GameSnake.Games
{
    public class GameFactoryConsole : GameFactory
    {
        public override Game Create(
            int width, int height, int snakeLength = 5)
        {
            var userInputFactory = new UserInputFactoryConsole();
            var scoreFactoryConsole = new ScoreFactoryConsole();
            var speedFactoryConsole = new SpeedFactoryConsole();
            var borderFactoryCreate = new BorderFactoryConsole();
            var snakeFactoryConsole = new SnakeFactoryConsole();
            var foodFactoryConsole = new FoodFactoryConsole();
            var gameMapFactoryConsole = new GameMapFactoryConsole();

            return new Game(
                width, height, snakeLength,
                userInputFactory,
                scoreFactoryConsole,
                speedFactoryConsole,
                borderFactoryCreate,
                snakeFactoryConsole,
                foodFactoryConsole,
                gameMapFactoryConsole);
        }
    }
}
