using GameSnake;
using GameSnake.Components;
using GameSnake.Extension;

const int HeightForScore = 2;

var height = 20;
var width = 40;

WindowSetting(width, height);
Game(height, width);
DisplayGameOver(width, height); //Massage "Game Over" 
Console.ReadKey();

void Game(int height, int width) {
    var directory = new Direction();

    var field = new Field(width + 1, height + 1);
    var snakeLen = 10;
    var snake = new Snake((width / 2) - snakeLen, height / 2, field, snakeLen);
    var food = new Food(field);
    var score = new Score(snake.Length, height);

    field.Draw();
    food.Draw();
    snake.Draw();
    score.Draw();

    GameLoop(snake, food, directory, score);
}

static void DisplayGameOver(int fieldWidth, int fieldHeight) {
    string message = "Game Over";
    int startWidthMessage = fieldWidth / 2 - message.Length / 2;
    int startHeightMessage = fieldHeight / 2;

    Console.SetCursorPosition(startWidthMessage, startHeightMessage);
    Console.WriteLine(message);
}

static void WindowSetting(int width, int height) {
    Console.SetWindowSize(width + 2, height + 2 + HeightForScore);
    Console.SetBufferSize(width + 2, height + 2 + HeightForScore);
    Console.CursorVisible = false;
    Console.Title = "SNAKE";
}

static void GameLoop(Snake snake, Food food, Direction direction, Score score) {
    while (true) {
        if (Console.KeyAvailable) {
            ConsoleKey key = Console.ReadKey().Key;
            var direct = key.ToDirection();
            if (direction.ChangeDirection(direct)) {
                snake.Direction = direction.Value;
            }
        }

        //Game over
        if (snake.Intersect()) {
            food.Clear();
            snake.Clear();
            break;
        }

        if (snake.EatFood(food.Position)) {
            while (snake.IntersectBody(food.Position)) {
                score.Draw();
                food.GeneratePosition();
            }
            score.Add();
            score.Draw();
            food.Draw();
        }
        else {
            snake.ClearTail();
            snake.Move();
            Thread.Sleep(100);
        }
        snake.DrawHead();
    }
}