using GameSnake;

var height = 20;
int width = 40;

Console.SetWindowSize(width, height);
Console.SetBufferSize(width, height);
Console.CursorVisible = false;


Console.Title = "SNAKE";
var snake = new Snake(width / 2, height / 2);
Console.ReadKey();

