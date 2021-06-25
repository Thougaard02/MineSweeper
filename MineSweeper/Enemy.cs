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

        private Player player;
        public Enemy(Player player)
        {
            this.player = player;

            do
            {
                X = rng.Next(0, ConsoleEx.Width);
                Y = rng.Next(0, ConsoleEx.Height);
            } while (GetDistanceToPlayer(player) < 10.0f);

            Speed = rng.Next(5, 10);
        }
        public void Logic()
        {
            float dX = Math.Sign(player.X - X);
            float dY = Math.Sign(player.Y - Y);

            X += dX / Speed;
            Y += dY / Speed;

            if (GetDistanceToPlayer(player) < 1.1f)
            {
                player.IsHit = true;
            }

        }
        private float GetDistanceToPlayer(Player player)
        {
            return MathF.Sqrt(MathF.Abs(MathF.Pow(player.X - X, 2) + MathF.Pow(player.Y - Y, 2)));
        }


    }
}
