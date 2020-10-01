using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

using System.Xml.Schema;

namespace TjuvochPolis
{
    class Program
    { 
        static void Main(string[] args)
        {

            const int numTjuv = 20;
            const int numMedborgare = 30;
            const int numPolis = 10;
            string vara, note;
            Prison prison = new Prison();


            Stad sto = new Stad();
                sto.rensaStad();
                
                Medborgare[] folk = new Medborgare[numMedborgare];
                for (int i = 0; i < numMedborgare; i++) folk[i] = new Medborgare();

              Polis[] polis = new Polis[numPolis];
            for (int i = 0; i < numPolis; i++) polis[i] = new Polis();

            Tjuv[] tjuv = new Tjuv[numTjuv];
                for (int i = 0; i < numTjuv; i++) tjuv[i] = new Tjuv();
           
            int sek = 0;
            do

            {        // skriver in i staden M  30 medborgare
                note = "";
                for (int k = 0; k < numMedborgare; k++)
                {
                    sto.insPerson('M', folk[k].x, folk[k].y);
                }
                //_______________________________________________________________________________________________
                //    lägger in tjuvar i staden 
                for (int k = 0; k < numTjuv; k++)
                {
                    if (tjuv[k].iPrison == true) continue; // tjuven är i fängelse
                        

                    if (sto.omMedinSto(tjuv[k].x, tjuv[k].y))
                    {
                        // tjuven träffar en medborgare och stjäl nånting
                        int nMed;

                        for (nMed = 0; nMed < numMedborgare; nMed++)
                            if (tjuv[k].x == folk[nMed].x && tjuv[k].y == folk[nMed].y) break;//såväl M som T ligger i samma cell om x är samma (se la x é la stessa sia M che T si trovano nella stessa casella)
                        vara = folk[nMed].stöld();   // en vara blir borttagen (sottratta) från invetory av medborgare 
                        tjuv[k].tjuVinst(vara);  // tjuven lägger in i sin inventory tjuvgodset

                        
                        note += "Tjuven tar ifrån Medborgare " + vara + "\n";
                    }

                    sto.insPerson('T', tjuv[k].x, tjuv[k].y);   // lägger in tjuv[k] in i staden sto
                     // continue  hoppar från if hit 
                }    
                //_______________________________________________________________________________________
                //  Polis i rörelse  (in azione)
                for (int k = 0; k < numPolis; k++)
                {
                    if (sto.omTjuvinSto(polis[k].x, polis[k].y))           // kollar om det finns en tjuv där polisen flyttas //( om det finns en tjuv där polis rör sig)
                    {
                        int nTju;

                        for (nTju = 0; nTju < numTjuv; nTju++)
                        {
                            if (polis[k].x == tjuv[nTju].x && polis[k].y == tjuv[nTju].y) break;// om x är samma då bägge M och T ligger i samma cell (casella).
                        }
                        vara = tjuv[nTju].tjuvgods();  // tjuvgodset som tjuven innehar (refurtiva in possesso del ladro) 
                            polis[k].tjuvgods(vara);  // Polis tar i beslag (sequestra) tjuvgodset från tjuven

                     //   note += "Polis tar ifrån tjuven   " + vara + "\n";
                       // prison.inPrison(tjuv[nTju]);   // tjuv[nTju] hamnar i prison 
                      //  note += "Polis har gripit tjuven  " + DateTime.Now.ToString() + "\n";
                       
                    }

                    sto.insPerson('P', polis[k].x, polis[k].y);
                    polis[k].flytta();
                }

                note += prison.outPrison();
                if (prison.RäknaTjuvarPrison().Length > 0)  
                    note += "\n Prison " + prison.RäknaTjuvarPrison() + " [ ] ";
                sto.skrivaStad(note);     // kollar och skriver ut om någon tjuv har befriats
                sto.rensaStad();

                //  flyttar alla personer i nya positioner  (spostiamo alla personer nelle nuove posizioni) 
                for (int k = 0; k < numMedborgare; k++) folk[k].flytta();     // Medborgaren flyttas

                for (int k = 0; k < numTjuv; k++) tjuv[k].flytta();     //Tjuven flyttas
                sek++;

            } while (sek < 300);

        }
        
        } 

        
    
}
