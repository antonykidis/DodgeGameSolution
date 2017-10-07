using System; // We need the standard .NET library for many things including console

namespace DodgeGame
{
    class DodgeGameMain
    {
        static void Main()
        {
            //Let's hide the blinking cursor. We won't need it.
            Console.CursorVisible = false;

            //Create a new game.
            Game game = new Game();

            //Run the game.
            game.Run();

            //When we get here, the game is over.


            //After program ends, set "Press any key to continue..." to bottom.

            Console.SetCursorPosition(0, Console.WindowHeight - 1);


        }
    }
}


