using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public delegate void GameEventHandler();
    public class Player
    {
        public GameEventHandler Lose;
        public float X { get; set; }
        public float Y { get; set; }

        public bool IsHit { get; set; }

        public Player()
        {
            X = ConsoleEx.Width / 2;
            Y = ConsoleEx.Height / 2;
            IsHit = false;
        }

        public void Logic()
        {
            if (Input.KeyState(Key.UP))
            {
                Y--;
            }
            else if (Input.KeyState(Key.DOWN))
            {
                Y++;
            }
            else if (Input.KeyState(Key.RIGHT))
            {
                X++;
            }
            else if (Input.KeyState(Key.LEFT))
            {
                X--;
            }
            HandleBorderCollision();
        }
        private void HandleBorderCollision()
        {
            if (X < 0)
            {
                X = 0;
            }
            else if (Y < 0)
            {
                Y = 0;
            }
            else if (Y > ConsoleEx.Height - 1)
            {
                Y = ConsoleEx.Height - 1;
            }
            else if (X > ConsoleEx.Width - 1)
            {
                X = ConsoleEx.Width - 1;
            }
        }
    }

}
