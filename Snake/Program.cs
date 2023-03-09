using GameSnake;
using GameSnake.Components;
using GameSnake.Extension;

const int HeightForScore = 2;

var height = 20;
var width = 40;

DisplaySettings(width, height);
Game(height, width);
DisplayGameOver(width, height); //Massage "Game Over" 
Console.ReadKey();

void Game(int height, int width) {
    var directory = new Direction();

    var field = new Field(width, height);
    var snake = new Snake(width / 2, height / 2, field, 10);
    var food = new Food(field);
    var score = new Score(snake.Length, field);

    food.Draw();
    GameLoop(snake, food, directory, score);
}

static void DisplayGameOver(int fieldWidth, int fieldHeight) {
    string message = "Game Over";
    int startWidthMessage = fieldWidth / 2 - message.Length / 2;
    int startHeightMessage = fieldHeight / 2;

    Console.SetCursorPosition(startWidthMessage, startHeightMessage);
    Console.WriteLine(message);
}

static void DisplaySettings(int width, int height) {
    Console.SetWindowSize(width + 1, height + 1 + HeightForScore);
    Console.SetBufferSize(width + 1, height + 1 + HeightForScore);
    Console.CursorVisible = false;
    Console.Title = "SNAKE";
}

static void GameLoop(Snake snake, Food food, Direction directory, Score score) {
    while (true) {
        if (Console.KeyAvailable) {
            ConsoleKey key = Console.ReadKey().Key;
            var direct = key.ToDirection();
            if (directory.ChangeDirection(direct)) {
                snake.Direction = directory.Turn;
            }
        }

        //Game over
        if (snake.Intersect()) {
            food.Clear();
            break;
        }

        if (snake.EatFood(food.Position)) {
            while (snake.IntersectBody(food.Position)) {
                score.Draw();
                food.SetPosition();
            }
            food.Draw();
        }
        else {
            snake.Move();
            snake.ClearTail();
            Thread.Sleep(100);
        }
        snake.DrawHead();
    }

}