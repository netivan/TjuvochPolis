using System;
using System.Collections.Generic;



namespace TjuvochPolis
{
    class Tjuv:Person
    {
        public bool iPrison = false;
        public DateTime timeArrest ;

        

        public void tjuVinst(string vara)
        {
            inventory.Add(vara);

        }

        public string tjuvgods()
        {
            string vara = "";

            if (inventory.Count == 0)      // om tjuven har ingen vara i sin inventory så blir hen inte gripen eller tvärtom
                iPrison = false;
            else {
                iPrison = true;
                    timeArrest = DateTime.Now;    // tid av arrest
                
                
            }

            while (inventory.Count > 0)
            {
                vara += inventory[0] + "  ";
                inventory.Remove(vara);   // tar bort varan från invetory
            }
            return vara;
        }
    }


}
