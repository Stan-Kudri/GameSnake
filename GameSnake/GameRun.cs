using Core;
using Core.Components;
using Microsoft.Extensions.DependencyInjection;

namespace GameSnake
{
    public class GameRun
    {
        private readonly GameFacade _gameFacade;
        private readonly GameMap _gameMap;

        public GameRun(IServiceProvider serviceProvider)
        {
            _gameFacade = serviceProvider.GetRequiredService<GameFacade>();
            _gameMap = serviceProvider.GetRequiredService<GameMap>();
        }

        public void Run()
        {
            do
            {
                _gameFacade.Update(TimeSpan.Zero);
                _gameFacade.Draw();
            }
            while (!_gameMap.IsGameOver());
        }
    }
}
