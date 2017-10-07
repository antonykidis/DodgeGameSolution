using System;

namespace DodgeGame
{
    abstract public class Unit
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

                //We are moving, so Undraw!
                Undraw();
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

                //Again, moving so Undraw!
                Undraw();
                _y = value;
            }
        }

        private int _y;     //Where the value of Y is actually stored.



        public string UnitGraphic;

        virtual public void Update( int deltaTimeMS )
        {
            //This is an instance method that gets run
            //every frame, where the Unit should resolve
            //any gamey things that are going on.
            //The idea is that all Units Update themselves,
            //then all Units will be Drawn.

            //Since this Update runs for both Player AND Enemy Units,
            //it needs to be overridden by child classes.
            
            //throw new Exception("We are in Unit::Update()");

        }

        //This draws the unit on the screen.
        virtual public void Draw()
        {
            //This is an instance method, so if we refer
            //to fields like x and y, we will be using
            //the values that belong to this instance
            //and this instance ONLY.
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(this.UnitGraphic);

        }

        //Undraws old character from screen.
        public void Undraw()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(' ');
        }

        public bool IsCollidingWith(Unit other)
        {
            //"this" is the current unit.
            //"other" is the other unit.

            if (this.X == other.X && this.Y == other.Y)
            {
                //We are in same square. Are colliding.
                return true;
            }

            return false;
        }

    }
}
