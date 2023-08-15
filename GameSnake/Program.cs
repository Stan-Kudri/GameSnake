using Core.Components;
using Core.Components.GameMapItems;
using GameSnake;
using GameSnake.ComponentsGame;
using GameSnake.ComponentsGame.ItemGameMap;
using GameSnake.ComponentsGame.ItemGameMap.Foods;
using GameSnake.Extension;
using Microsoft.Extensions.DependencyInjection;

const int HeightForScore = 2;

var height = 20;
var width = 40;

var service = new ServiceCollection()
    .AddSingleton(new BorderSize(width, height))
    .AddSingleton<Border, BorderConsole>()
    .AddSingleton<Snake, SnakeConsole>()
    .AddScoped<FoodFactoryConsole>()
    .AddSingleton<UserInput>(new UserInputConsole())
    .AddSingleton<Score>(new ScoreConsole(height))
    .AddScoped<SpeedConsole>()
    .AddScoped(x => new GameMapConsole(
        x.GetRequiredService<Border>(),
        x.GetRequiredService<Snake>(),
        x.GetRequiredService<FoodFactoryConsole>()))
    .AddScoped<GameOver>(x => new GameOverConsole(x.GetRequiredService<Border>()))
    .AddScoped<ConsoleGame>();

using var container = service.BuildServiceProvider();
using var serviceScope = container.CreateScope();
var game = serviceScope.ServiceProvider.GetRequiredService<ConsoleGame>();

HeightForScore.WindowSetting(width, height);
game.Run();
Console.ReadKey();
