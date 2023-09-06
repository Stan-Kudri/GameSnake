using Core;
using Core.Components;
using Core.Components.GameMapItems;
using Core.Components.GameMapItems.Foods;
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
    .AddScoped<Border, BorderConsole>()
    .AddScoped<Snake, SnakeConsole>()
    .AddScoped<FoodFactory, FoodFactoryConsole>()
    .AddSingleton<UserInput, UserInputConsole>()
    .AddSingleton<Score>(new ScoreConsole(height))
    .AddScoped<Speed, SpeedConsole>()
    .AddScoped<GameMap, GameMapConsole>()
    .AddScoped<GameOver, GameOverConsole>()
    .AddScoped<GameFacade>()
    .AddScoped<GameRun>();

using var container = service.BuildServiceProvider();
using var serviceScope = container.CreateScope();
var game = serviceScope.ServiceProvider.GetRequiredService<GameRun>();

HeightForScore.WindowSetting(width, height);
game.Run();
Console.ReadKey();
