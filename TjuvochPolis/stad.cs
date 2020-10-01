using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TjuvochPolis
{
    class Stad
    {

        
        public const int Xmax = 26;
        public const int Ymax = 101;
        public int antalRån = 0;
        public int antalGripna = 0;
        public int conteggio = 0;
        public char[,] city = new char[Xmax, Ymax];
        public Stad()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("             Tjuv  och  Polis  ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void rensaStad()                         // fyller i  rutorna av arrayn city   (spazi della matrice city)
        {
            for (int i = 0; i < Xmax; i++)

                for (int j = 0; j < Ymax; j++)

                    city[i, j] = ' ';
        }
        public void skrivaStad(string varning)
        {
            //  Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            string ss = "";

            for (int i = 0; i < Xmax; i++)
            {
                for (int j = 0; j < Ymax; j++)
                {

                    ss += city[i, j]; 
                }

                //    ss += "\n";
                Console.SetCursorPosition(1, i + 2);
                Console.WriteLine(ss);
                ss = "";
            }
            //  Console.WriteLine(ss);
            //Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(conteggio);
            conteggio++;

            if (varning.Length > 1)
            {
                Console.WriteLine(varning);
                Console.Beep();
                Console.WriteLine($"Antal rånade medborgare: {antalRån}");
                Console.WriteLine($"Antal gripna tjuvar: {antalGripna}");
                Thread.Sleep(400); // Paus i 2000 millisekunder = 4
            } else
                Thread.Sleep(100); // Paus i 500 millisekunder = 0,1
           // Console.ReadLine();
        }

        public void insPerson(char p, int x, int y)
        {
            city[x, y] = p;
        }

        public bool omMedinSto(int x ,int y)
        {
            if (city[x, y] == 'M')
            {
                antalRån++;
                return true;
            }
            else return false;
        }

        public bool omTjuvinSto(int x, int y)           // om tjuven träffar polis
        {
            if (city[x, y] == 'T')
            {
                antalGripna++;
                return true;
            }
            else return false;
        }
    }

}