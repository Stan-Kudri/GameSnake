using GameSnake;
using GameSnake.Components;
using GameSnake.Enum;
using GameSnake.Extension;

var gameOver = false;
var height = 20;
var width = 40;

Game(height, width);
Console.ReadKey();

void Game(int height, int width) {
    ConsoleViewSetting(width, height);

    var directory = new Direct(Directions.Left);

    var field = new Field(width, height);
    var snake = new Snake(width / 2, height / 2, field, 10);
    var food = new Food(field);

    food.Create();
    food.Eat.Draw();

    while (gameOver == false) {
        if (Console.KeyAvailable) {
            ConsoleKey key = Console.ReadKey().Key;
            var direct = key.ToDirection();
            if (directory.ChangeDirection(direct)) {
                snake.Direction = directory.Value;
            }
        }

        if (!snake.Move(ref food)) {
            gameOver = true;
        }

        Thread.Sleep(100);
    }
    WriteMessage(width, height); //Game Over
}

static void WriteMessage(int fieldWidth, int fieldHeight) {
    string message = "Game Over";
    int startWidthMessage = fieldWidth / 2 - message.Length / 2;
    int startHeightMessage = fieldHeight / 2;

    Console.SetCursorPosition(startWidthMessage, startHeightMessage);
    Console.WriteLine(message);
}

static void ConsoleViewSetting(int width, int height) {
    Console.SetWindowSize(width + 2, height + 2);
    Console.SetBufferSize(width + 2, height + 2);
    Console.CursorVisible = false;
    Console.Title = "SNAKE";
}