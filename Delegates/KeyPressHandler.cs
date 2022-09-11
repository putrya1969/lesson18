using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate void ChangeDirHandler(Directions directions);
    public class KeyPressHandler
    {
        internal event ChangeDirHandler ChangeDirection;
        public Directions currentDirection { get; set; }
        public void DirectionSelector(ConsoleKeyInfo consoleKeyInfo)
        {
            Directions direction = new Directions();
            switch (consoleKeyInfo.Key)
            {

                case ConsoleKey.UpArrow:
                    {
                        direction = Directions.Up;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        direction = Directions.Left;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        direction = Directions.Right;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        direction = Directions.Down;
                        break;
                    }
            }
            if (currentDirection != direction)
            {
                if (IsOpposite(direction))
                    return;
                ChangeDirection?.Invoke(direction);
                currentDirection = direction;
            }
        }

        bool IsOpposite(Directions direction)
        {
            if (((currentDirection == Directions.Right) && (direction == Directions.Left)) ||
                ((currentDirection == Directions.Left) && (direction == Directions.Right)) ||
                ((currentDirection == Directions.Up) && (direction == Directions.Down)) ||
                ((currentDirection == Directions.Down) && (direction == Directions.Up)))
                return true;
            return false;
        }
    }
}
