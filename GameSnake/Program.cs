using System.Runtime.InteropServices;
using GameSnake;
using GameSnake.ComponentsGame;
using GameSnake.ComponentsGame.ItemGameMap;
using GameSnake.ComponentsGame.ItemGameMap.Foods;
using Microsoft.Extensions.DependencyInjection;

const int HeightForScore = 2;

var height = 20;
var width = 40;
var snakeLength = 5;

WindowSetting(width, height);

var service = new ServiceCollection()
    .AddSingleton(new BorderConsole(width, height))
    .AddSingleton(x => new SnakeConsole(x.GetRequiredService<BorderConsole>(), snakeLength))
    .AddScoped<FoodFactoryConsole>()
    .AddScoped<UserInputConsole>()
    .AddSingleton(new ScoreConsole(height))
    .AddScoped<SpeedConsole>()
    .AddScoped(x => new GameMapConsole(
        x.GetRequiredService<BorderConsole>(),
        x.GetRequiredService<SnakeConsole>(),
        x.GetRequiredService<FoodFactoryConsole>()))
    .AddScoped(x => new GameOverConsole(x.GetRequiredService<BorderConsole>()))
    .AddScoped<ConsoleGame>();

using var serviceScope = service.BuildServiceProvider().CreateScope();

var userInput = serviceScope.ServiceProvider.GetRequiredService<UserInputConsole>();
var scoreConsole = serviceScope.ServiceProvider.GetRequiredService<ScoreConsole>();
var speedConsole = serviceScope.ServiceProvider.GetRequiredService<SpeedConsole>();
var gameOver = serviceScope.ServiceProvider.GetRequiredService<GameOverConsole>();
var gameMapConsole = serviceScope.ServiceProvider.GetRequiredService<GameMapConsole>();

var game = new ConsoleGame(userInput, scoreConsole, speedConsole, gameMapConsole, gameOver);
game.Run();

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
