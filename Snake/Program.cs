using GameSnake;
using GameSnake.Enum;

const int HeightForScore = 2;

var height = 20;
var width = 40;

WindowSetting(width, height);

var type = TypeSnakeSelection();
var game = new Game(width, height, type);
game.Run();

DisplayGameOver(width, height); //Massage "Game Over" 

Console.ReadKey();

static void WindowSetting(int width, int height)
{
    Console.SetWindowSize(width + 2, height + 2 + HeightForScore);
    Console.SetBufferSize(width + 2, height + 2 + HeightForScore);
    Console.CursorVisible = false;
    Console.Title = "SNAKE";
}

static TypeSnake TypeSnakeSelection()
{
    Console.WriteLine("Types of snake game:\n1-The snake does not passing the borders;\n2-The snake passes through the borders.\n\nInput of the selected type:");
    var type = TypeSnake.Unknown;

    while (type == TypeSnake.Unknown)
    {
        var key = Console.ReadKey(true);
        if (int.TryParse(key.KeyChar.ToString(), out var numberType))
        {
            if (numberType == 1)
            {
                type = TypeSnake.NotPassingBorders;
            }
            else if (numberType == 2)
            {
                type = TypeSnake.PassingBorders;
            }
        }
    }

    Console.Clear();

    return type;
}

static void DisplayGameOver(int fieldWidth, int fieldHeight)
{
    string message = "Game Over";
    int startWidthMessage = fieldWidth / 2 - message.Length / 2;
    int startHeightMessage = fieldHeight / 2;

    Console.SetCursorPosition(startWidthMessage, startHeightMessage);
    Console.WriteLine(message);
}