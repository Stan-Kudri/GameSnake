using Core.Components.GameMapItems;

namespace Core.Components
{
    public abstract class GameOver
    {
        protected readonly Border _border;

        public GameOver(Border border) => _border = border;

        // Massage "Game Over"
        public abstract void Draw();
    }
}
