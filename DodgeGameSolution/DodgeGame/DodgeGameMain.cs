using System; // We need the standard .NET library for many things including console

namespace DodgeGame
{
    class DodgeGameMain
    {
        static void Main()
        {


            //Instantiate a Unit that will represent the player.
            //Unit constructor's signature: X pos, Y pos, Char.
            Unit playerUnit = new Unit(10, 5, "@");

            //Instantiate a Unit that will represent the enemy.
            //Unit constructor's signature: X pos, Y pos, Char.
            Unit enemyUnit = new Unit(20, 17, "X");

            //Test dummy Unit.
            //Unit testUnit = new Unit(1, 2, "3");

            //Draw Units.
            playerUnit.Draw();
            enemyUnit.Draw();
            //testUnit.Draw();
            
            
            //After program ends, set "Press any key to continue..." to bottom.

            Console.SetCursorPosition(0, Console.WindowHeight - 1);


        }
    }
}


