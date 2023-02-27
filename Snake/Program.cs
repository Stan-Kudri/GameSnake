using GameSnake;
using GameSnake.Enum;

var height = 20;
var width = 40;
var directory = new Direct(Directions.Right);

Console.SetWindowSize(width + 2, height + 2);
Console.SetBufferSize(width + 2, height + 2);
Console.CursorVisible = false;
Console.Title = "SNAKE";

var snake = new Snake(width / 2, height / 2, 4);

while (true) {
    if (Console.KeyAvailable) {
        ConsoleKeyInfo key = Console.ReadKey();
        if (directory.NewDirection(key)) {
            snake.Direction = directory.Value;
        }
    }
    snake.Move();
}
Console.ReadKey();

