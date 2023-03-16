using GameSnake.Components.ItemGameMap;
using GameSnake.Extension;

namespace GameSnake.Components
{
    public class GameMap
    {
        public const int NumberRandomSearchPosition = 3;

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

        public void ChangeSnakeDirection(UserInput direction) => _snake.Direction = direction.CurrentDirection;

        public void Move()
        {
            if (_snake.EatFood(_food.Position))
            {
                OnEatScore?.Invoke(_food);

                if (!RandomSearchCellForFood())
                {
                    SearchCellForFood();
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

        private bool RandomSearchCellForFood()
        {
            for (var i = 0; i < NumberRandomSearchPosition; i++)
            {
                var newPositionFood = _border.GenerateFoodPosition();
                if (!_snake.IntersectBody(newPositionFood))
                {
                    _food = new Food(newPositionFood);
                    return true;
                }
            }

            return false;
        }

        private bool SearchCellForFood()
        {
            for (var x = 1; x < _border.Width - 1; x++)
            {
                for (var y = 1; y < _border.Height - 1; y++)
                {
                    var newPositionFood = new Point(x, y);
                    if (!_snake.IntersectBody(newPositionFood))
                    {
                        _food = new Food(newPositionFood);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
