using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    internal class FajlBeolvasas
    {
        public static List<Auto> BeolvasCSV(string filePath)
        {
            List<Auto> autok = new List<Auto>();
            bool isFirstLine = true; 

            foreach (var line in File.ReadLines(filePath))
            {
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue; 
                }

                string[] adatok = line.Split(',');
                if (adatok.Length == 4)
                {
                    autok.Add(new Auto(adatok[0], adatok[1],  Convert.ToInt32(adatok[2]), decimal.Parse(adatok[3])));
                }
            }
            return autok;
        }
    }
}
