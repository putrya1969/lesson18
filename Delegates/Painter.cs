using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class Painter
    {
        const char borderSymbol = '#';
        const char appleSymbol = '@';
        const char snakeSymbol = 'X';
        public Snake Snake { get; }
        public PlayingField PlayingField { get; }

        public Painter(Snake snake, PlayingField playingField)
        {
            Snake = snake;
            PlayingField = playingField;
            DrawBorder(borderSymbol);
            DrawSymbol(snake.SnakesBodyItems[0].X, snake.SnakesBodyItems[0].Y, snakeSymbol);
            DrawApple(snake.Apple.X, snake.Apple.Y, appleSymbol);
            Console.SetCursorPosition(1, 1);
            snake.SnakeMove += RedrawSnake;
            snake.SnakeGrow += GrowSnake;
            snake.GameIsOver += DrawGameOver;
        }

        private void DrawGameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.Write("GAME OVER!!!");
        }

        void RedrawSnake()
        {
            DrawSymbol(Snake.SnakesBodyItems[0].X, Snake.SnakesBodyItems[0].Y, snakeSymbol);
            EraseSymbol(Snake.SnakesBodyItems[Snake.SnakesBodyItems.Count - 1].X, Snake.SnakesBodyItems[Snake.SnakesBodyItems.Count - 1].Y);
        }

        void GrowSnake()
        {
            DrawSymbol(Snake.SnakesBodyItems[0].X, Snake.SnakesBodyItems[0].Y, snakeSymbol);
            DrawApple(Snake.Apple.X, Snake.Apple.Y, appleSymbol);
        }

        void DrawSymbol(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        void EraseSymbol(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        void DrawBorder(char symbol)
        {
            Console.WriteLine(new string(symbol, PlayingField.MaxPoint.X));
            for (int i = 1; i < PlayingField.MaxPoint.Y; i++)
            {
                Console.SetCursorPosition(PlayingField.MinPoint.X, i);
                Console.Write(symbol);
                Console.SetCursorPosition(PlayingField.MaxPoint.X - 1, i);
                Console.Write(symbol);
            }
            Console.SetCursorPosition(PlayingField.MinPoint.X, PlayingField.MaxPoint.Y);
            Console.WriteLine(new string(symbol, PlayingField.MaxPoint.X));
        }

        void DrawApple(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }
}
