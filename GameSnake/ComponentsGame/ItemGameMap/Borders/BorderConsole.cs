using Core.Components.GameMapItems.Borders;
using GameSnake.Extension;

namespace GameSnake.ComponentsGame.ItemGameMap.Borders
{
    public class BorderConsole : Border
    {
        public const char SymbolField = '*';

        public BorderConsole(int width, int height)
            : base(width, height)
        {
        }

        public override void Draw() => Borders.ForEach(x => x.Draw(SymbolField));
    }
}
