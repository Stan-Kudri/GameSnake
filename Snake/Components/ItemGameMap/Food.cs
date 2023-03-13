using GameSnake.Extension;

namespace GameSnake.Components.ItemGameMap {
    public class Food {
        public const char SymbolEat = '@';

        public Food(Point position, int scorePoint = 1) {
            Position = position;
            Score = scorePoint;
        }

        public Point Position { get; private set; }

        public int Score { get; private set; }

        public void Draw() => Position.Draw(SymbolEat);

        public void Clear() => Position.Clear();
    }
}
