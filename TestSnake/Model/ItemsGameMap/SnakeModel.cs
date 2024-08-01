using Core.Components.GameMapItems;

namespace TestSnake.Model.ItemsGameMap
{
    public class SnakeModel : Snake
    {
        public SnakeModel(Border border, int length = 3)
            : base(border, length)
        {
        }

        // No implementation
        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
