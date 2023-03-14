using GameSnake.Components.ItemGameMap;
using GameSnake.Extension;

namespace GameSnake.Components
{
    public class GameMap
    {
        public event Action<Food>? OnEatScore;

        private readonly Border _border;

        private Food _food;
        private Snake _snake;

        public GameMap(int width, int height, int snakeLength = 10)
        {
            _border = new Border(width, height);
            _food = new Food(_border.GenerateFoodPosition());
            _snake = new Snake((width / 2) - snakeLength, height / 2, _border, snakeLength);
        }

        public bool GameOver => _snake.Intersect();

        public int HeightBoard() => _border.Height;


        public void ChangeSnakeDirection(Direction direction) => _snake.Direction = direction.Value;

        public void Move()
        {
            if (_snake.EatFood(_food.Position))
            {
                OnEatScore?.Invoke(_food);
                while (_snake.IntersectBody(_food.Position))
                {
                    _food = new Food(_border.GenerateFoodPosition());
                }
            }
            else
            {
                _snake.Move();
            }
        }

        public void DrawBoarder() => _border.Draw();

        public void Draw()
        {
            _snake.Draw();
            _food.Draw();
        }

        public void Clear()
        {
            _snake.Clear();
            _food.Clear();
        }
    }
}
