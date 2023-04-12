using Core.Components;
using GameSnake.ComponentsGame.ItemGameMap;
using GameSnake.Extension;

namespace GameSnake.ComponentsGame
{
    public class GameMapConsole : GameMap
    {
        public const char SymbolEat = '@';

        public GameMapConsole(BorderConsole border, SnakeConsole snake)
            : base(border, snake)
        {
        }

        public override void ChangeSnakeDirection(IUserInput direction) => _snake.Direction = direction.CurrentDirection;

        public override void Draw()
        {
            _snake.Draw();
            _food.Position.Draw(SymbolEat);
            _border.Draw();
        }

        public override void Clear()
        {
            _snake.Clear();
            _food.Position.Clear();
        }
    }
}
