using System;

namespace DodgeGame
{
    public class PlayerUnit : Unit
    {
        public PlayerUnit(int x, int y, string unitGraphic) : base(x, y, unitGraphic)
        {
            

            
        }

        override public void Update(int deltaTimeMS)
        {
            //When the PLAYER's Update gets called, we would
            //like to run this instead of our parent class's Update.
            //In other words, we want to override the parent.
            

            //Has the user pressed a key?
            if(Console.KeyAvailable == true)
            {
                //If so, let's MOVE based on that key input.

                ConsoleKeyInfo cki = Console.ReadKey(true);
                
                switch(cki.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (Y > 0)
                        {
                            Y -= 1;
                        }
                            break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (Y < Console.WindowHeight - 1)
                        {
                            Y += 1;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        if (X > 0)
                        {
                            X -= 1;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        if (X < Console.WindowWidth - 1)
                        {
                            X += 1;
                        }
                        break;
                }
                //After "break", we end up here.

            }



            //Now that our keyboard input is done,
            //let's call the base class's Update function 
            //in case it has any important work to do.
            base.Update(deltaTimeMS);
        }

    }
}
