﻿using GameSnake.Components;
using GameSnake.Components.ItemGameMap;
using GameSnake.ComponentsGame;
using GameSnake.Extension;

namespace GameSnake
{
    public class Game
    {
        private GameMap _gameMap;
        private UserInput _userInput;
        private Score _score;
        private Speed _speed;

        public Game(int width, int height, int snakeLength = 5)
        {
            if (snakeLength <= 0)
            {
                throw new ArgumentException("Length snake more zero.", nameof(snakeLength));
            }

            if (width < 1 || height < 1)
            {
                throw new ArgumentException("Invalid board size.");
            }

            _userInput = new UserInput();
            _score = new Score(height);
            _speed = new Speed();

            var border = new Border(width, height);
            var snake = snakeLength.Create(border);

            _gameMap = new GameMap(border, snake);
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
