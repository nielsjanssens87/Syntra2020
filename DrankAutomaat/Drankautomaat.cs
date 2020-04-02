using System;
using System.Collections.Generic;
using System.Text;

namespace DrankAutomaat
{
    class Drankautomaat
    {
        //ipv aparte dranken beter lijst van Drank
        public Drank Cola { get; set; }
        public Drank Water { get; set; }
        public Drank Fruitsap { get; set; }

        public Drankautomaat()
        {
            Cola = new Drank();
            Water = new Drank();
            Fruitsap = new Drank();
        }
        public Drankautomaat(int aantCola, int aantWater, int aantFruitsap)
        {
            Cola = new Drank("Cola",aantCola, 2.2m);
            Water = new Drank("Water",aantWater, 1.25m);
            Fruitsap = new Drank("Fruitsap",aantFruitsap, 2.1m);
        }
        //public void VulBij (int aant, string dranknaam)
        //{

        //}


        
        public string Keuze (int keuze, decimal aantalGeld)
        {
            string output = "";
            output += $"U koos {keuze}: ";
            decimal teBetalen = 0;
            switch (keuze)
            {
                case 1:
                    output += " Cola";
                    teBetalen = Cola.Prijs;
                    break;
                case 2:
                    output += " Water";
                    teBetalen = Water.Prijs;
                    break;
                case 3:
                    output += " Fruitsap";
                    teBetalen = Fruitsap.Prijs;
                    break;
                default:
                    output += "?";
                    break;
            }
            if (aantalGeld < teBetalen)
            {
                output += $"\nU komt {Math.Round((teBetalen - aantalGeld),2)} euro te kort";
            }
            else
            {
                if (BerrekenVoorraad(keuze))
                {
                    output += "\nU krijgt terug: ";
                    output += "\n" + BerrekenTeruggave(teBetalen, aantalGeld);
                }
                else
                {
                    output += "\nDit product is niet voorradig";
                    output += "\nU krijgt terug: ";
                    output += "\n" + BerrekenTeruggave(0, aantalGeld);
                }
                
            }
            return output;
        }
        private bool BerrekenVoorraad(int kz)
        {
            bool opvoorraad = false;
            switch (kz)
            {
                case 1:
                    if (Cola.Aantal > 0)
                    {
                        Cola.Aantal -= 1;
                        opvoorraad = true;
                    }
                    
                    break;
                case 2:
                    if (Water.Aantal > 0)
                    {
                        Water.Aantal -= 1;
                        opvoorraad = true;
                    }
                    break;
                case 3:
                    if (Fruitsap.Aantal > 0)
                    {
                        Fruitsap.Aantal -= 1;
                        opvoorraad = true;
                    }
                    break;
                default:
                    break;
            }
            return opvoorraad;
        }
        private string BerrekenTeruggave(decimal tebetalen, decimal betaald)
        {
            decimal teruggave = betaald - tebetalen;
            int aant2eur;
            int aant1eur;
            int aant50ct;
            int aant20ct;
            int aant10ct;
            int aant5ct;
            //int aant2ct = 0;
            //int aant1ct = 0;
            string strTeruggave = "";
            if (teruggave / 2 > 0)
            {
                aant2eur = Convert.ToInt32(Math.Floor(teruggave / 2));
                teruggave -= aant2eur*2;
                strTeruggave += "" + aant2eur + " munten van 2 euro";
            }
            if(teruggave / 1 > 0)
            {
                aant1eur = Convert.ToInt32(Math.Floor(teruggave));
                teruggave -= aant1eur;
                strTeruggave += "\n" + aant1eur + " munten van 1 euro";
            }
            if (teruggave / 0.5m > 0)
            {
                aant50ct = Convert.ToInt32(Math.Floor(teruggave / 0.5m));
                teruggave -= aant50ct * 0.5m;
                strTeruggave += "\n" + aant50ct + " munten van 50 cent";
            }
            if (teruggave / 0.2m > 0)
            {
                aant20ct = Convert.ToInt32(Math.Floor(teruggave / 0.2m));
                teruggave -= aant20ct * 0.2m;
                strTeruggave += "\n" + aant20ct + " munten van 20 cent";
            }
            if (teruggave / 0.1m > 0)
            {
                aant10ct = Convert.ToInt32(Math.Floor(teruggave / 0.1m));
                teruggave -= aant10ct * 0.1m;
                strTeruggave += "\n" + aant10ct + " munten van 10 cent";
            }
            if (teruggave / 0.05m > 0)
            {
                aant5ct = Convert.ToInt32(Math.Floor(teruggave / 0.05m));
                teruggave -= aant5ct * 0.05m;
                strTeruggave += "\n" + aant5ct + " munten van 5 cent";
            }

            
            
            
            return strTeruggave;
        }

        public override string ToString()
        {
            string tekst="";
            tekst += "---Drankautomaat---\n";
            tekst += "\n1. Cola     - prijs: " + this.Cola.Prijs + " euro. " + this.Cola.Aantal + " stuks beschikbaar";
            tekst += "\n2. Water    - prijs: " + this.Water.Prijs + " euro. " + this.Water.Aantal + " stuks beschikbaar";
            tekst += "\n3. Fruitsap - prijs: " + this.Fruitsap.Prijs + " euro. " + this.Fruitsap.Aantal + " stuks beschikbaar";
            return tekst;
        }
    }
}
