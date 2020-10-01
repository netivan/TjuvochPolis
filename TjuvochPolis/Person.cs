using System;
using System.Collections.Generic;


namespace TjuvochPolis
{
    class Person
    {
        public int ymax = 100;
        public int xmax = 25;
        public int x;
        public int y;
        public int ydirection;
        public int xdirection;   

       public  List<string> inventory = new List<string>();

        
        public Person()
        {
            Random r = new Random();

            x = r.Next(1, xmax);
            y = r.Next(1, ymax);
            xdirection = r.Next(-1,2);
            ydirection = r.Next(-1,2);
            if (xdirection == 0 & ydirection == 0)      { xdirection = 1; ydirection = 1; }
        }
        public void flytta()                    

        {
            if (x == 0 || x >= xmax)

                xdirection = xdirection * (-1);

            if (y == 0 || y >= ymax)

                ydirection = ydirection * (-1);

            x = x + xdirection;
            y = y + ydirection;
        }
    }
}
