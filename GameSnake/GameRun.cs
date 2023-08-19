using Core;
using Core.Components;

namespace GameSnake
{
    public class GameRun
    {
        private readonly GameFacade _gameFacade;
        private readonly GameMap _gameMap;

        public GameRun(GameFacade gameFacade, GameMap gameMap)
        {
            _gameFacade = gameFacade;
            _gameMap = gameMap;
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
