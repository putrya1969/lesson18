using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Delegates
{
    delegate void MoveTo();
    internal class Snake
    {
        Random random = new Random();

        public delegate void SnakeEventHandler();

        public PlayingField PlayingField { get; set; }
        public List<SnakesBodyItem> SnakesBodyItems { get; set; } = new List<SnakesBodyItem>();
        public Apple Apple { get; set; }

        public MoveTo MoveDirection;

        public event SnakeEventHandler SnakeMove;

        public event SnakeEventHandler SnakeGrow;

        public event SnakeEventHandler GameIsOver;
        public bool EndGame{ get; set; }

        public Snake(KeyPressHandler keyPressHandler, PlayingField playingField)
        {
            SnakesBodyItems.Add(new SnakesBodyItem(random.Next(1, 50), random.Next(1, 20)));
            SetDirection(keyPressHandler.currentDirection);
            keyPressHandler.ChangeDirection += SetDirection;
            Apple = new Apple(random.Next(1, 50), random.Next(1, 20));
            PlayingField = playingField;
            EndGame = false;
        }

        public void Move()
        {
            MoveDirection();
            if (OutField())
            {
                GameIsOver?.Invoke();
                EndGame = true;
            }
            if ((SnakesBodyItems[0].X == Apple.X) && (SnakesBodyItems[0].Y == Apple.Y))
            {
                Apple = new Apple(random.Next(1, 50), random.Next(1, 20));
                SnakeGrow?.Invoke();
            }
            else
            {
                SnakeMove?.Invoke();
                Retreat();
            }
        }

        private bool OutField()
        {
            return ((SnakesBodyItems[0].X == PlayingField.MinPoint.X) ||
                (SnakesBodyItems[0].X == PlayingField.MaxPoint.X) ||
                (SnakesBodyItems[0].Y == PlayingField.MinPoint.Y) ||
                (SnakesBodyItems[0].Y == PlayingField.MaxPoint.Y));
        }

        void Right()
        {
            SnakesBodyItems.Insert(0, new SnakesBodyItem(SnakesBodyItems[0].X + 1, SnakesBodyItems[0].Y));
        }
        void Left()
        {
            SnakesBodyItems.Insert(0, new SnakesBodyItem(SnakesBodyItems[0].X - 1, SnakesBodyItems[0].Y));
        }
        void Down()
        {
            SnakesBodyItems.Insert(0, new SnakesBodyItem(SnakesBodyItems[0].X, SnakesBodyItems[0].Y + 1));
        }
        void Up()
        {
            SnakesBodyItems.Insert(0, new SnakesBodyItem(SnakesBodyItems[0].X, SnakesBodyItems[0].Y - 1));
        }

        void Retreat()
        {
            SnakesBodyItems.RemoveAt(SnakesBodyItems.Count - 1);
        }

        private void SetDirection(Directions directions)
        {
            switch (directions)
            {
                case Directions.Right:
                    {
                        MoveDirection = Right;
                        break;
                    }
                case Directions.Left:
                    {
                        MoveDirection = Left;
                        break;
                    }
                case Directions.Up:
                    {
                        MoveDirection = Up;
                        break;
                    }
                case Directions.Down:
                    {
                        MoveDirection = Down;
                        break;
                    }
            }
        }
    }
}
