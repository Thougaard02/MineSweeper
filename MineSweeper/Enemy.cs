using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathFloat;
namespace MineSweeper
{
    public class Enemy
    {
        static Random rng = new Random();

        public float X { get; set; }
        public float Y { get; set; }

        public float Speed { get; set; }

        public Enemy()
        {
            X = rng.Next(0, ConsoleEx.Width);
            Y = rng.Next(0, ConsoleEx.Height);
            Speed = rng.Next(5, 10);
        }
        public void Logic(Player player)
        {
            float dX = Math.Sign(player.X - X);
            float dY = Math.Sign(player.Y - Y);

            X += dX / Speed;
            Y += dY / Speed;

            if (GetDistanceToPlayer(player) < 1.1f)
            {
                player.IsHit = true;
                //Fixed Jonas's spaghetti code by comment it out
                //player.Lose?.Invoke();
            }
        }
        float GetDistanceToPlayer(Player player)
        {
            return MathF.Abs(MathF.Sqrt(MathF.Pow(player.X - X, 2) + MathF.Pow(player.Y - Y, 2)));
        }
    }

}
