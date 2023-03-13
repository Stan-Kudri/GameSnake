using GameSnake.Components.ItemGameMap;
using GameSnake.Extension;

namespace GameSnake.Components {
    public class GameMap {
        private readonly Border _border;

        private Food _food;
        private Snake _snake;

        public GameMap(int width, int height, int snakeLength = 10) {
            _border = new Border(width, height);
            _food = new Food(_border.GenerateFoodPosition());
            _snake = new Snake((width / 2) - snakeLength, height / 2, _border, snakeLength);
        }

        public bool GameOver => _snake.Intersect();

        public void ChangeSnakeDirection(Direction direction) => _snake.Direction = direction.Value;

        public void Movie(out int scoreFood) {
            scoreFood = 0;
            if (_snake.EatFood(_food.Position)) {
                scoreFood = _food.Score;
                while (_snake.IntersectBody(_food.Position)) {
                    _food = new Food(_border.GenerateFoodPosition());
                }
            }
            else {
                _snake.Move();
            }
        }

        public void DrawBoarder() => _border.Draw();

        public void Draw() {
            _snake.Draw();
            _food.Draw();
        }

        public void Clear() {
            _snake.Clear();
            _food.Clear();
        }

        public int SnakeLength() => _snake.Length;
    }
}
