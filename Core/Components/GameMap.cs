using Core.Components.GameMapItems;
using Core.Extension;

namespace Core.Components
{
    public abstract class GameMap
    {
        public const int NumberRandomSearchPosition = 3;

        protected readonly Border _border;

        protected readonly Snake _snake;

        protected Food _food;

        public GameMap(Border border, Snake snake)
        {
            _border = border;
            _snake = snake;
            _food = RandomCellForFood() ?? SearchCellForFood() ?? throw new Exception("There is no empty cell for food.");
        }

        public event Action<Food>? OnEatScore;

        public bool IsGameOver() => _snake.ObstacleCollision() || _snake.Intersect();

        public abstract void ChangeSnakeDirection(IUserInput direction);

        public void Move()
        {
            if (_snake.TryEatFood(_food.Position))
            {
                OnEatScore?.Invoke(_food);
                _food = RandomCellForFood() ?? SearchCellForFood() ?? throw new Exception("There is no empty cell for food.");
            }

            _snake.Move();
        }

        public abstract void Draw();

        public abstract void Clear();

        private Food? RandomCellForFood()
        {
            for (var i = 0; i < NumberRandomSearchPosition; i++)
            {
                var newPositionFood = _border.GenerateFoodPosition();

                if (!_snake.IntersectBody(newPositionFood))
                {
                    return new Food(newPositionFood);
                }
            }

            return null;
        }

        private Food? SearchCellForFood()
        {
            for (var x = 1; x < _border.Width - 1; x++)
            {
                for (var y = 1; y < _border.Height - 1; y++)
                {
                    var newPositionFood = new Point(x, y);

                    if (!_snake.IntersectBody(newPositionFood))
                    {
                        return new Food(newPositionFood);
                    }
                }
            }

            return null;
        }
    }
}
