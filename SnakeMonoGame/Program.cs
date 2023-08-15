using Core.Components;
using Core.Components.GameMapItems;
using Core.Components.GameMapItems.Foods;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameSnake.ComponentsGame;
using MonoGameSnake.ComponentsGame.ItemGameMap;
using MonoGameSnake.ComponentsGame.ItemGameMap.Foods;
using SnakeMonoGame;

var collection = new ServiceCollection()
    .AddSingleton(new BorderSize(20, 20))
    .AddScoped<Game, SnakeMonoGame.MonoGame>()
    .AddScoped(e => new SpriteBatch(e.GetRequiredService<Game>().GraphicsDevice))
    .AddScoped<TextureHolder>()
    .AddScoped<GraphicsDeviceManager>()
    .AddScoped<UserInput, UserInputMono>()
    .AddScoped<Speed, SpeedMono>()
    .AddScoped<Border, BorderMono>()
    .AddScoped<Snake, SnakeMono>()
    .AddScoped<Score, ScoreMono>()
    .AddScoped<FoodFactory, FoodFactoryMono>()
    .AddScoped<GameMap, GameMapMono>()
    .AddScoped<GameOver, GameOverMono>()
    .AddScoped<GameFacade>();

using var contain = collection.BuildServiceProvider(new ServiceProviderOptions
{
    ValidateOnBuild = true,
    ValidateScopes = true,
});

using var scope = contain.CreateScope();
var game = scope.ServiceProvider.GetRequiredService<Game>();
game.Run();
