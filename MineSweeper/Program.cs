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
            ConsoleEx.SetFont("Consolas", 12, 16);

            Random random = new Random();
            player = new Player();

            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTick;
            timer.Start();

            //Fixed Jonas's spaghetti code by comment it out
            //player.Lose = OnLose;

            while (true)
            {
                ConsoleEx.WriteLine("Score: " + score);
                player.Logic();
                AddEnemy();
                IsPlayerHit();
                ConsoleEx.WriteCharacter((int)player.X, (int)player.Y, 'A', Color.Cyan);
                Thread.Sleep(25);
                ConsoleEx.Update();
                ConsoleEx.Clear();
            }
        }

        //Fixed Jonas's spaghetti code by comment it out 
        //private static void OnLose()
        //{
        //    score = 0;

        //    //Bug can die 2 times instance of new player
        //    //player = new Player();
        //}

        private static void OnTick(object sender, System.Timers.ElapsedEventArgs e)
        {
            enemyList.Add(new Enemy());
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
                enemyList[i].Logic(player);
                ConsoleEx.WriteCharacter((int)enemyList[i].X, (int)enemyList[i].Y, 'B', Color.Red);
            }
        }
    }
}
