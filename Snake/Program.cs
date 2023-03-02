﻿using GameSnake;
using GameSnake.Enum;

var gameOver = false;
var height = 20;
var width = 40;

Game(height, width);
Console.ReadKey();

void Game(int height, int width) {
    var directory = new Direct(Directions.Left);

    Console.SetWindowSize(width + 2, height + 2);
    Console.SetBufferSize(width + 2, height + 2);
    Console.CursorVisible = false;
    Console.Title = "SNAKE";

    var field = new Field(width, height);
    var snake = new Snake(width / 2, height / 2, field, 10);

    while (gameOver == false) {
        if (Console.KeyAvailable) {
            ConsoleKey key = Console.ReadKey().Key;
            var direct = GetDirection(key);
            if (directory.ChangeDirection(direct)) {
                snake.Direction = directory.Value;
            }
        }
        if (!snake.Move()) {
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

static Directions GetDirection(ConsoleKey key) {
    switch (key) {
        case ConsoleKey.UpArrow:
            return Directions.Up;
        case ConsoleKey.DownArrow:
            return Directions.Down;
        case ConsoleKey.LeftArrow:
            return Directions.Left;
        case ConsoleKey.RightArrow:
            return Directions.Right;
        default:
            return Directions.Other;
    }
}

