using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    internal class Autok
    {
        public string Marka { get; private set; }
        public string Tipus { get; private set; }
        public int Evjarat { get; private set; }
        public decimal Ar { get; private set; }

        public Auto(string marka, string tipus, int evjarat, decimal ar)
        {
            Marka = marka;
            Tipus = tipus;
            Evjarat = evjarat;
            Ar = ar;
        }

        public string GetInsertValues()
        {
            return $"'{Marka}', '{Tipus}', {Evjarat}, {Ar}";
        }

        public override string ToString()
        {
            return $"{Marka} {Tipus} ({Evjarat}) - {Ar:C}";
        }
    }
}
