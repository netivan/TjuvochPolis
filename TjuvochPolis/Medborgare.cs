using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvochPolis
{
    class Medborgare : Person
    {
        string[] varor = { "Nycklar", "Mobiltelefon", "Pengar", "klocka" };

        public Medborgare()   // constructor
        {
            inventory.Add(varor[0]);
            inventory.Add(varor[1]);
            inventory.Add(varor[2]);
            inventory.Add(varor[3]);

        }
         public string stöld ()
        { string vara = "inget";
            if (inventory.Count > 0)
            {
                vara = inventory[0];
                inventory.Remove(vara);   // tar bort varan från inventory 
            }

            return vara;
        }

    }

    
}
