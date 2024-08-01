using Core;
using Core.Components.GameMapItems.Foods;

namespace TestSnake.Model.ItemsGameMap.Foods
{
    public class FoodModel : Food
    {
        public FoodModel(Point position, int scorePoint = 1)
            : base(position, scorePoint)
        {
        }

        // No implementation
        public override void Draw()
        {
        }
    }
}
