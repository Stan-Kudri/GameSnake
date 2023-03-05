using GameSnake;
using GameSnake.Components;
using GameSnake.Extension;

var height = 20;
var width = 40;

ConsoleViewSetting(width, height);
Game(height, width);
WriteMessage(width, height); //Massage "Game Over" 
Console.ReadKey();

void Game(int height, int width) {
    var directory = new Direct();

    var field = new Field(width, height);
    var snake = new Snake(width / 2, height / 2, field, 10);
    var food = new Food(field);

    food.Draw();

    while (true) {
        if (Console.KeyAvailable) {
            ConsoleKey key = Console.ReadKey().Key;
            var direct = key.ToDirection();
            if (directory.ChangeDirection(direct)) {
                snake.Direction = directory.Value;
            }
        }

        //Game over
        if (snake.Intersect()) {
            food.Clear();
            break;
        }

        if (snake.EatFood(food.Value)) {
            while (snake.IsFreePoint(food)) {
                food.New();
            }
            food.Draw();
        }
        else {
            snake.Move();
            Thread.Sleep(100);

        }
    }
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