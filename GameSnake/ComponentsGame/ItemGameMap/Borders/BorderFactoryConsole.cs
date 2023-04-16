using Core.Components.GameMapItems.Borders;

namespace GameSnake.ComponentsGame.ItemGameMap.Borders
{
    public class BorderFactoryConsole : BorderFactory
    {
        public override BorderConsole Create(int width, int height) => new BorderConsole(width, height);
    }
}
