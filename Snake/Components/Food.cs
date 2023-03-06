using GameSnake.Extension;

namespace GameSnake.Components {
    public class Food {
        public const char SymbolEat = '@';

        private Field _field;

        public Point Position { get; set; }

        public Food(Field field) {
            _field = field;
            Position = field.NewPosition();
        }

        public void SetPosition() => Position = _field.NewPosition();

        public void Draw() => Position.Draw(SymbolEat);

        public void Clear() => Position.Clear();
    }
}
