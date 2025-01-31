using CarRental;
using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
internal class Program
{
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nAutókölcsönző rendszer");
                Console.WriteLine("1. Adatbázis létrehozás és CSV importálás");
                Console.WriteLine("2. Új autó hozzáadása");
                Console.WriteLine("3. Legnépszerűbb autó lekérdezése");
                Console.WriteLine("4. Legdrágább autó lekérdezése");
                Console.WriteLine("5. Kilépés");
                Console.Write("Válassz egy opciót: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AdatbazisLetrehozasEsImportalas();
                        break;
                    case "2":
                        UjAutoHozzaadas();
                        break;
                    case "3":
                        LegnepszerubbAutoLekerdezes();
                        break;
                    case "4":
                        LegdragabbAutoLekerdezes();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Érvénytelen választás!");
                        break;
                }
            }
        }
       
}

   