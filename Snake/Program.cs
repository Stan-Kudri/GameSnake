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
    var gameMap = new GameMap(width, height);
    var score = new Score(gameMap.SnakeLength(), height);

    gameMap.DrawBoarder();
    gameMap.Draw();
    score.Draw();

    GameLoop(gameMap, directory, score);
}

static void WindowSetting(int width, int height) {
    Console.SetWindowSize(width + 2, height + 2 + HeightForScore);
    Console.SetBufferSize(width + 2, height + 2 + HeightForScore);
    Console.CursorVisible = false;
    Console.Title = "SNAKE";
}

static void GameLoop(GameMap gameMap, Direction direction, Score score) {
    while (true) {
        if (Console.KeyAvailable) {
            ConsoleKey key = Console.ReadKey().Key;
            var direct = key.ToDirection();
            if (direction.ChangeDirection(direct)) {
                gameMap.ChangeSnakeDirection(direction);
            }
        }

        //Game over
        if (gameMap.GameOver) {
            gameMap.Clear();
            break;
        }

        gameMap.Clear();

        gameMap.Movie(out var scoreFood);
        gameMap.Draw();

        score.Increase(scoreFood);
        score.Draw();

        Thread.Sleep(100);
    }
}

static void DisplayGameOver(int fieldWidth, int fieldHeight) {
    string message = "Game Over";
    int startWidthMessage = fieldWidth / 2 - message.Length / 2;
    int startHeightMessage = fieldHeight / 2;

    Console.SetCursorPosition(startWidthMessage, startHeightMessage);
    Console.WriteLine(message);
}