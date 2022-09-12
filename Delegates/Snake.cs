using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
    delegate void MoveTo();
    internal class Snake
    {
        Random random = new Random();

        public delegate void SnakeEventHandler();
        public delegate void SnakeHandler(Snake sender);

        public PlayingField PlayingField { get; set; }
        public List<SnakesBodyItem> SnakesBodyItems { get; set; } = new List<SnakesBodyItem>();
        public Apple Apple { get; set; }

        public MoveTo MoveDirection;

        public event SnakeHandler SnakeMove;

        public event SnakeHandler SnakeGrow;

        public event SnakeEventHandler GameIsOver;
        public bool EndGame{ get; set; }

        public Snake(KeyPressHandler keyPressHandler, PlayingField playingField, SnakesBodyItem firstSnakeBody)
        {
            SnakesBodyItems.Add(firstSnakeBody);
            SetDirection(keyPressHandler.currentDirection);
            keyPressHandler.ChangeDirection += SetDirection;
            PlayingField = playingField;
            EndGame = false;
            SnakeMove += Painter.RedrawSnake;
            SnakeGrow += Program.NewApple;
            SnakeGrow += Painter.GrowSnake;
            GameIsOver += Painter.DrawGameOver;
        }

        public void Move()
        {
            MoveDirection();
            if (OutField())
            {
                GameIsOver?.Invoke();
                EndGame = true;
            }
            if ((SnakesBodyItems.First().X == Apple.X) && (SnakesBodyItems.First().Y == Apple.Y))
            {
                SnakeGrow?.Invoke(this);
            }
            else
            {
                SnakeMove?.Invoke(this);
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
            SnakesBodyItems.Insert(0, new SnakesBodyItem(SnakesBodyItems.First().X + 1, SnakesBodyItems.First().Y));
        }
        void Left()
        {
            SnakesBodyItems.Insert(0, new SnakesBodyItem(SnakesBodyItems.First().X - 1, SnakesBodyItems.First().Y));
        }
        void Down()
        {
            SnakesBodyItems.Insert(0, new SnakesBodyItem(SnakesBodyItems.First().X, SnakesBodyItems.First().Y + 1));
        }
        void Up()
        {
            SnakesBodyItems.Insert(0, new SnakesBodyItem(SnakesBodyItems.First().X, SnakesBodyItems.First().Y - 1));
        }

        void Retreat()
        {
            //SnakesBodyItems = SnakesBodyItems.Skip(1).ToList();
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
