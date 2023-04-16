using Core.Components.GameMapItems.Borders;
using Core.Components.GameMapItems.Foods;
using Core.Components.GameMapItems.Snakes;
using Core.Components.GameMaps;
using Core.Components.Scores;
using Core.Components.Speeds;
using Core.Components.UserInputs;
using Core.Extension;

namespace Core.Games
{
    public class Game
    {
        private readonly GameMap _gameMap;
        private readonly IUserInput _userInput;
        private readonly Score _score;
        private readonly Speed _speed;

        public Game(
            int width, int height, int snakeLength,
            UserInputFactory userInputFactory,
            ScoreFactory scoreFactory,
            SpeedFactory speedFactory,
            BorderFactory borderFactory,
            SnakeFactory snakeFactory,
            FoodFactory foodFactory,
            GameMapFactory gameMapFactory)
        {
            if (snakeLength <= 0)
            {
                throw new ArgumentException("Length snake more zero.", nameof(snakeLength));
            }

            if (width < 1 || height < 1)
            {
                throw new ArgumentException("Invalid board size.");
            }

            _userInput = userInputFactory.Create();
            _score = scoreFactory.Create(height);
            _speed = speedFactory.Create();

            var border = borderFactory.Create(width, height);
            var snake = snakeFactory.Creator(border, snakeLength);

            _gameMap = gameMapFactory.Create(border, snake, foodFactory);
            _userInput.OnChangedDirection += _gameMap.ChangeSnakeDirection;
            _gameMap.OnEatScore += _score.Increase;
            _score.OnUpIntervalScore += _speed.Increase;
        }

        public void Run()
        {
            while (!_gameMap.IsGameOver())
            {
                _gameMap.Clear();

                _userInput.Update();
                _gameMap.Move();

                _gameMap.Draw();
                _score.Draw();

                _speed.Apply();
            }

            _gameMap.Clear();
        }
    }
}
