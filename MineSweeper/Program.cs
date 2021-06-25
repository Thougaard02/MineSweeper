using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Engine;

namespace MineSweeper
{
    class Program
    {
        static List<Enemy> enemyList = new List<Enemy>();
        static Player player;
        static int score = 0;
        static void Main(string[] args)
        {
            ConsoleEx.Create(50, 36);
            ConsoleEx.SetFont("Consolas", 18, 24);

            Random random = new Random();
            player = new Player();

            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTick;
            timer.Start();

            while (true)
            {
                ConsoleEx.WriteLine("Score: " + score);
                player.Logic();
                AddEnemy();
                IsPlayerHit();
                ConsoleEx.WriteCharacter((int)player.X, (int)player.Y, '☺', Color.Cyan);
                Thread.Sleep(25);
                ConsoleEx.Update();
                ConsoleEx.Clear();
            }
        }
        private static void OnTick(object sender, System.Timers.ElapsedEventArgs e)
        {
            enemyList.Add(new Enemy(player));
            score++;
        }

        private static void IsPlayerHit()
        {
            if (player.IsHit)
            {
                score = 0;
                enemyList.Clear();
                player.IsHit = false;
                player.X = ConsoleEx.Width / 2;
                player.Y = ConsoleEx.Height / 2;
            }
        }
        private static void AddEnemy()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Logic();
                ConsoleEx.WriteCharacter((int)enemyList[i].X, (int)enemyList[i].Y, '☻', Color.Red);
            }
        }
    }
}
