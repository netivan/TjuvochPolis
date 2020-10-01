using System;
using System.Collections.Generic;
using System.Text;


namespace TjuvochPolis
{
    class Prison
    {


        List<Tjuv> tjuvar = new List<Tjuv>();
        


        public void inPrison(Tjuv x) 
        {
            tjuvar.Add(x);
        } 


        public string outPrison()
        {
            string s = "";

            foreach (Tjuv x in tjuvar)
            {
                TimeSpan diff = DateTime.Now - x.timeArrest;
                double seconds = diff.TotalSeconds;

                if (diff.TotalSeconds >29 )  

                { tjuvar.Remove(x);
                    x.iPrison = false;

                    s = "En tjuv blir fri";
                    return s;
                }
            }
            return s;
        }

        public string RäknaTjuvarPrison()
        {
            string s = "";
                                                                  // for ( int i = 0; i < tjuvar.count ; i++) s+= "T" 
                    
            foreach (Tjuv x in tjuvar)
                s += " [T] ";

            

            return s;

        }

    }
}
