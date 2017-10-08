using System;

namespace DodgeGame
{
    public class EnemyUnit : Unit
    {
        //This is just a generic enemy unit that moves from
        //the right side of the screen to the left and then
        //disappears.

        public EnemyUnit(int x, int y, string unitGraphic) : base (x, y, unitGraphic)
        {
            //Be dormant for up to a second.
            sleepForMS = Game.Random.Next(0, 2000);

            TimeBetweenMoves = Game.Random.Next(40, 60);
        }

        public int TimeBetweenMoves; //in Milliseconds.
        private int timeSinceLastMove = 0;

        private int sleepForMS = 0;

        public override void Update(int deltaTimeMS)
        {

            sleepForMS -= deltaTimeMS;
            if (sleepForMS > 0)
            {
                //We are still asleep, do nothing.
                return;
            }

            //Has enough time passed that we should be moving?
            timeSinceLastMove += deltaTimeMS;

            if (timeSinceLastMove < TimeBetweenMoves)
            {
                //Not enough time has passed, let's not do anything!
                return; //exits function.
            }

            //If we get here, it means we need to make a move.
            timeSinceLastMove -= TimeBetweenMoves;

            //Do AI stuffs here!

            //These enemies go from the right side of the screen
            //to the left. If they go out of bounds, then we delete
            //ourselves... how does that work?

            //Move one to the left, but only if we can still move to the left.
            if (X > 0)
            {
                X -= 1;
            }
            else
            {
                //We are at our move limit, so let's move back to the right side
                //of the screen.
                X = Console.WindowWidth - 1;
                //And randomize our row (do not spawn on bottom row).
                Y = Game.Random.Next(0, Console.WindowHeight - 1);
                //And sleep a little bit.
                sleepForMS = Game.Random.Next(0, 1000);
                //Every time enemy spawns, get a little bit faster.
                //by reducing TimeBetweenMoves.
                TimeBetweenMoves = TimeBetweenMoves * 95 / 100;
                if (TimeBetweenMoves < 10)
                {
                    //Keep Time to something sane.
                    TimeBetweenMoves = 10;
                }

                //Give the player a point.
                Game.Score += 1;
            }

            //Now that the AI calculation is done,
            //let's call the base class's Update function 
            //in case it has any important work to do.
            base.Update(deltaTimeMS);
        }

        override public void Draw()
            {
                if(sleepForMS > 0)
                {
                   //Stil asleep, do not draw us.
                   return;
                }

                //We are awake.
                base.Draw();

            }

    }
    
}
