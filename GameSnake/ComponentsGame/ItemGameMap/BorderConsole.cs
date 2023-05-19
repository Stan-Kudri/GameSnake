using Core.Components.GameMapItems;
using GameSnake.Extension;

namespace GameSnake.ComponentsGame.ItemGameMap
{
    public class BorderConsole : Border
    {
        private const char SymbolField = '*';

        public BorderConsole(int width, int height)
            : base(width, height)
        {
        }

        public override void Draw() => Borders.ForEach(x => x.Draw(SymbolField));
    }
}
