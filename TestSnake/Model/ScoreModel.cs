using Core.Components;

namespace TestSnake.Model
{
    public class ScoreModel : Score
    {
        public ScoreModel(int height, int points = 0)
            : base(height, points)
        {
        }

        // No implementation
        public override void Draw()
        {
        }
    }
}
