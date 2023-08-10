using Core.Components;
using GameSnake;
using GameSnake.ComponentsGame;
using GameSnake.ComponentsGame.ItemGameMap;
using GameSnake.ComponentsGame.ItemGameMap.Foods;
using GameSnake.Extension;
using Microsoft.Extensions.DependencyInjection;

const int HeightForScore = 2;

var height = 20;
var width = 40;
var snakeLength = 5;

var service = new ServiceCollection()
    .AddSingleton(new BorderConsole(width, height))
    .AddSingleton(x => new SnakeConsole(x.GetRequiredService<BorderConsole>(), snakeLength))
    .AddScoped<FoodFactoryConsole>()
    .AddSingleton<UserInput>(new UserInputConsole())
    .AddSingleton<Score>(new ScoreConsole(height))
    .AddScoped<SpeedConsole>()
    .AddScoped(x => new GameMapConsole(
        x.GetRequiredService<BorderConsole>(),
        x.GetRequiredService<SnakeConsole>(),
        x.GetRequiredService<FoodFactoryConsole>()))
    .AddScoped<GameOver>(x => new GameOverConsole(x.GetRequiredService<BorderConsole>()))
    .AddScoped<ConsoleGame>();

using var container = service.BuildServiceProvider();
using var serviceScope = container.CreateScope();
var game = serviceScope.ServiceProvider.GetRequiredService<ConsoleGame>();

HeightForScore.WindowSetting(width, height);
game.Run();
Console.ReadKey();
