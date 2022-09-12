using System;
using System.Threading;

namespace Delegates
{
    class Program
    {
        static public Random random = new Random();
        static void Main(string[] args)
        {
            var keyPressHandler = new KeyPressHandler();
            var playField = new PlayingField();

            var snake = new Snake(keyPressHandler, playField, new SnakesBodyItem(random.Next(1, 50), random.Next(1, 20)));
            var apple = new Apple(random.Next(1, 50), random.Next(1, 20));
            snake.Apple = apple;
            Painter.DrawBorder(playField);
            Painter.DrawSymbol(apple.X, apple.Y, '@');
            Console.CursorVisible = false;
            while (!snake.EndGame)
            {
                snake.Move();
                if (Console.KeyAvailable)
                    keyPressHandler.DirectionSelector(Console.ReadKey(true));
                Thread.Sleep(150);
            }
            Console.ReadKey();
        }

        public static void NewApple(Snake snake)
        {
            var newApple = new Apple(random.Next(1, 50), random.Next(1, 20));
            snake.Apple = newApple;
        }

    }
    public enum Directions
    {
        Right,
        Down,
        Left,
        Up
    }
}
