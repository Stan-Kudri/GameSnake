using GameSnake.Extension;

namespace GameSnake.Components {
    public class Food {
        public const char SymbolEat = '@';

        private Border _field;

        public Point Position { get; private set; }

        public Food(Border field) {
            _field = field;
            Position = field.GeneratePosition();
        }

        public void GeneratePosition() => Position = _field.GeneratePosition();

        public void Draw() => Position.Draw(SymbolEat);

        public void Clear() => Position.Clear();
    }
}
