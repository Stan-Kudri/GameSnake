using Core.Components.GameMapItems;
using Core.Components.GameMapItems.Foods;
using Core.Extension;

namespace Core.Components
{
    public abstract class GameMap
    {
        private const int NumberRandomSearchPosition = 3;

        private readonly FoodFactory _foodFactory;
        private readonly Border _border;
        private readonly Snake _snake;

        private Food _food;

        public GameMap(Border border, Snake snake, FoodFactory foodFactory)
        {
            _foodFactory = foodFactory;
            _border = border;
            _snake = snake;
            _food = RandomCellForFood() ?? SearchCellForFood() ?? throw new Exception("There is no empty cell for food.");
        }

        public event Action<Food>? OnEatScore;

        public Snake Snake => _snake;

        public Food Food => _food;

        public bool IsGameOver() => _snake.ObstacleCollision() || _snake.Intersect();

        public void ChangeSnakeDirection(UserInput direction) => _snake.Direction = direction.CurrentDirection;

        public void Move()
        {
            if (_snake.TryEatFood(_food.Position))
            {
                OnEatScore?.Invoke(_food);
                _food = RandomCellForFood() ?? SearchCellForFood() ?? throw new Exception("There is no empty cell for food.");
            }

            _snake.Move();
        }

        public void Draw()
        {
            _food.Draw();
            _snake.Draw();
            _border.Draw();
        }

        private Food? RandomCellForFood()
        {
            for (var i = 0; i < NumberRandomSearchPosition; i++)
            {
                var newPositionFood = _border.GenerateFoodPosition();

                if (!_snake.IntersectBody(newPositionFood))
                {
                    return _foodFactory.Create(newPositionFood);
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
                        return _foodFactory.Create(newPositionFood);
                    }
                }
            }

            return null;
        }
    }
}
