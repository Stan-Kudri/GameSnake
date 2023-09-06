using Core.Components;
using Core.Components.GameMapItems;
using GameSnake.Extension;

namespace GameSnake.ComponentsGame.ItemGameMap
{
    public class BorderConsole : Border
    {
        private const char SymbolField = '*';

        public BorderConsole(BorderSize size)
            : base(size)
        {
        }

        public override void Draw() => Borders.ForEach(x => x.Draw(SymbolField));
    }
}
