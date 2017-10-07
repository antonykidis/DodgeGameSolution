using System;
using System.Threading;
using System.Diagnostics;

namespace DodgeGame
{
    public class Game
    {
        public Game()
        {
            //Instantiate a Unit that will represent the player.
            //Unit constructor's signature: X pos, Y pos, Char.
            playerUnit = new PlayerUnit(10, 17, "@");

            //Instantiate a Unit that will represent the enemy.
            //Unit constructor's signature: X pos, Y pos, Char.

            //Instantiate the array that will hold our enemies.
            enemyUnits = new Unit[numEnemies];
            //Right now, our enemyUnits array is instantiated,
            //but each slot is empty.


            Random = new Random();
            Score = 0;


            for(int i = 0; i < enemyUnits.Length; i++)
            {
                int row = Random.Next(0, Console.WindowHeight - 1);
                enemyUnits[i] = new EnemyUnit(Console.WindowWidth - 1, row, "X");
            }


            stopwatch = new Stopwatch();
        }

        public static Random Random;
        public static int Score;

        private Stopwatch stopwatch;

        private Unit playerUnit;

        private int numEnemies = 20;
        private Unit[] enemyUnits;

        public void Run()
        {
            stopwatch.Start();
            long timeAtPreviousFrame = stopwatch.ElapsedMilliseconds;



            while (true)
            {
                //The time since the last frame.
                int deltaTimeMS = (int)(stopwatch.ElapsedMilliseconds - timeAtPreviousFrame);
                timeAtPreviousFrame = stopwatch.ElapsedMilliseconds;

                //First, Update all of our Units.
                playerUnit.Update(deltaTimeMS);

                //For each enemy
                for (int i = 0; i < enemyUnits.Length; i++)
                {
                    //Update this enemy
                    enemyUnits[i].Update(deltaTimeMS);

                    //Now that both the player and this enemy have moved, 
                    //let's see if the player
                    //is colliding with this enemy. IF so, then Game Over!
                    if (playerUnit.IsCollidingWith(enemyUnits[i]))
                    {
                        //Then Game Over!
                        GameOver();
                        return;
                    }
                }

                //Then Draw Units.
                playerUnit.Draw();

                foreach (Unit u in enemyUnits)
                {
                    u.Draw();
                }

                //Draw the score!
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write("Score: " + Game.Score);

                //Let's just do a TINY sleep as to avoid running at a million FPS.
                Thread.Sleep( 5 );
                
            }

        }

        void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.WriteLine();
            Console.WriteLine("Your final score is " + Game.Score + "!");
            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }

}
