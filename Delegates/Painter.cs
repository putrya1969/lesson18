using System;
using System.Linq;

namespace Delegates
{
    internal static class Painter
    {
        const char borderSymbol = '#';

        const char appleSymbol = '@';

        const char snakeSymbol = 'X';
        public static PlayingField PlayingField { get; }

        public static void DrawGameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.Write("GAME OVER!!!");
        }

        public static void RedrawSnake(Snake snake)
        {
            DrawSymbol(snake.SnakesBodyItems.First().X, snake.SnakesBodyItems.First().Y, snakeSymbol);
            EraseSymbol(snake.SnakesBodyItems.Last().X, snake.SnakesBodyItems.Last().Y);
        }

        public static void GrowSnake(Snake snake)
        {
            DrawSymbol(snake.SnakesBodyItems.First().X, snake.SnakesBodyItems.First().Y, snakeSymbol);
            DrawApple(snake.Apple.X, snake.Apple.Y, appleSymbol);
        }

        public static void DrawSymbol(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        public static void EraseSymbol(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        public static void DrawBorder(PlayingField playingField)
        {
            Console.WriteLine(new string(borderSymbol, playingField.MaxPoint.X));
            for (int i = 1; i < playingField.MaxPoint.Y; i++)
            {
                Console.SetCursorPosition(playingField.MinPoint.X, i);
                Console.Write(borderSymbol);
                Console.SetCursorPosition(playingField.MaxPoint.X - 1, i);
                Console.Write(borderSymbol);
            }
            Console.SetCursorPosition(playingField.MinPoint.X, playingField.MaxPoint.Y);
            Console.WriteLine(new string(borderSymbol, playingField.MaxPoint.X));
        }

        static void DrawApple(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }
}
//cool!
