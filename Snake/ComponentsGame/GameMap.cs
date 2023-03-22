using GameSnake.Components.ItemGameMap;
using GameSnake.ComponentsGame;
using GameSnake.ComponentsGame.ItemGameMap.SnakeType;
using GameSnake.Enum;
using GameSnake.Extension;

namespace GameSnake.Components
{
    public class GameMap
    {
        public const int NumberRandomSearchPosition = 3;

        public event Action<Food>? OnEatScore;

        private readonly Border _border;
        private readonly ISnake _snake;

        private Food _food;

        public GameMap(int width, int height, TypeSnake type, int snakeLength = 10)
        {
            _border = new Border(width, height);
            _food = new Food(_border.GenerateFoodPosition());

            _snake = CreateSnake(type, _border) ?? throw new ArgumentException("Unknown type of snake.");

        }

        public bool GameOver => _snake.Intersect();

        public void ChangeSnakeDirection(UserInput direction) => _snake.Direction = direction.CurrentDirection;

        public void Move()
        {
            if (_snake.EatFood(_food.Position))
            {
                OnEatScore?.Invoke(_food);
                _food = RandomCellForFood() ?? SearchCellForFood() ?? throw new Exception("There is no empty cell for food.");
            }
            else
            {
                _snake.Move();
            }
        }

        public void Draw()
        {
            _snake.Draw();
            _food.Draw();
            _border.Draw();
        }

        public void Clear()
        {
            _snake.Clear();
            _food.Clear();
        }

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

        private static Snake? CreateSnake(TypeSnake type, Border border, int snakeLength = 10)
        {
            if (type == TypeSnake.NotPassingBorders)
            {
                return new SnakeNotPassingBorders((border.Height / 2) - snakeLength, border.Height / 2, border, snakeLength);
            }
            else if (type == TypeSnake.PassingBorders)
            {
                return new SnakePassingBorders((border.Width / 2) - snakeLength, border.Height / 2, border, snakeLength);
            }
            else
            {
                return null;
            }

        }
    }
}
