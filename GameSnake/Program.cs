using System.Runtime.InteropServices;
using GameSnake.Games;

const int HeightForScore = 2;

var height = 20;
var width = 40;

WindowSetting(width, height);

var game = new GameFactoryConsole().Create(width, height);
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

static void DisplayGameOver(int fieldWidth, int fieldHeight)
{
    string message = "Game Over";
    int startWidthMessage = (fieldWidth / 2) - (message.Length / 2);
    int startHeightMessage = fieldHeight / 2;

    Console.SetCursorPosition(startWidthMessage, startHeightMessage);
    Console.WriteLine(message);
}
