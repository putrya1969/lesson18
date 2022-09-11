using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyPressHandler = new KeyPressHandler();
            var snake = new Snake(keyPressHandler, new PlayingField());
            var painter = new Painter(snake, snake.PlayingField);
            Console.CursorVisible = false;
            while (!snake.EndGame)
            {
                snake.Move();
                if (Console.KeyAvailable)
                    keyPressHandler.DirectionSelector(Console.ReadKey(true));
                Thread.Sleep(300);
            }
            Console.ReadKey();
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
