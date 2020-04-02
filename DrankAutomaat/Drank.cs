using System;
using System.Collections.Generic;
using System.Text;

namespace DrankAutomaat
{
    class Drank
    {
        public decimal Prijs { get; set; } = 0;
        public int Aantal { get; set; } = 0;
        public string Dranknaam { get; set; }
        public Drank()
        {

        }
        public Drank(string drankaam, int aantal = 0, decimal prijs = 0)
        {
            Dranknaam = drankaam;
            Prijs = prijs;
            Aantal = aantal;
        }
        public override string ToString()
        {
            return "--"+ Dranknaam + "--\nprijs: " + Prijs.ToString() + "\naantal: " + Aantal.ToString();
        }

    }
}
