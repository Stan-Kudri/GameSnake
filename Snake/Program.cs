using GameSnake;
using GameSnake.Enum;

var height = 20;
var width = 40;

Game(height, width);


void Game(int height, int width) {
    var directory = new Direct(Directions.Left);

    Console.SetWindowSize(width + 2, height + 2);
    Console.SetBufferSize(width + 2, height + 2);
    Console.CursorVisible = false;
    Console.Title = "SNAKE";

    var field = new Field(width, height);
    var snake = new Snake(width / 2, height / 2, field, 10);

    while (true) {
        if (Console.KeyAvailable) {
            ConsoleKeyInfo key = Console.ReadKey();
            if (directory.ChangeDirection(key.Key)) {
                snake.Direction = directory.Value;
            }
        }
        snake.Move();
    }
}
Console.ReadKey();

