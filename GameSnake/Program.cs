using System.Runtime.InteropServices;
using Core;
using GameSnake.ComponentsGame;
using GameSnake.ComponentsGame.ItemGameMap;
using GameSnake.ComponentsGame.ItemGameMap.Foods;
using GameSnake.Extension;

const int HeightForScore = 2;

var height = 20;
var width = 40;
var snakeLength = 5;

WindowSetting(width, height);

var game = GameCreator(width, height, snakeLength);
game.Run();

DisplayGameOver(width, height); // Massage "Game Over"

Console.ReadKey();

static void WindowSetting(int width, int height)
{
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    {
        Console.SetWindowSize(width + 2, height + 2 + HeightForScore);
        Console.SetBufferSize(width + 2, height + 2 + HeightForScore);
    }

    Console.CursorVisible = false;
    Console.Title = "SNAKE";
}

static Game GameCreator(int width, int height, int snakeLength)
{
    var userInput = new UserInput();
    var scoreConsole = new ScoreConsole(height);
    var speedConsole = new SpeedConsole();

    var borderConsole = new BorderConsole(width, height);
    var snakeConsole = borderConsole.Creator(snakeLength);
    var foodFactoryConsole = new FoodFactoryConsole();

    var gameMapConsole = new GameMapConsole(borderConsole, snakeConsole, foodFactoryConsole);

    return new Game(userInput, scoreConsole, speedConsole, gameMapConsole);
}

static void DisplayGameOver(int fieldWidth, int fieldHeight)
{
    string message = "Game Over";
    int startWidthMessage = (fieldWidth / 2) - (message.Length / 2);
    int startHeightMessage = fieldHeight / 2;

    Console.SetCursorPosition(startWidthMessage, startHeightMessage);
    Console.WriteLine(message);
}
