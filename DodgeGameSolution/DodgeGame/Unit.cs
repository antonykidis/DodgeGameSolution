using System;

namespace DodgeGame
{
    public class Unit
    {

        public Unit(int x, int y, string UnitGraphic)
        {
            this.UnitGraphic = UnitGraphic;
            this.X = x;
            this.Y = y;
        }


        public int X        //The way the rest of the program interacts with X.
        {
            get
            {
                return _x;
            }

            set
            {
                if (value < 0 || value >= Console.WindowWidth)
                {
                    throw new Exception("Invalid X coordinates received.");
                }

                _x = value;
            }
        }

        private int _x;     //Where the value of X is actually stored.
        


        public int Y        //The way the rest of the program interacts with Y.
        {
            get
            {
                return _y;
            }

            set
            {
                if (value < 0 || value >= Console.WindowHeight)
                {
                    throw new Exception("Invalid Y coordinates received.");
                }

                _y = value;
            }
        }

        private int _y;     //Where the value of Y is actually stored.



        public string UnitGraphic;



        //This draws the unit on the screen.
        public void Draw()
        {
            //This is an instance method, so if we refer
            //to fields like x and y, we will be using
            //the values that belong to this instance
            //and this instance ONLY.
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(this.UnitGraphic);

        }

    }
}
