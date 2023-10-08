using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace employee2
{
    internal class Program
    {

        static Dictionary<string, double> Gazdagok(List<Dolgozo> a)
        {
            var gazdagok = new Dictionary<string, double>();
            foreach (var dolgozo in a)
            {
                if (dolgozo.AnnualSalaryInHuf > 5000000 && !gazdagok.ContainsKey(dolgozo.Name))
                {
                    gazdagok.Add(dolgozo.Name, dolgozo.AnnualSalaryInHuf);
                }
            }
            return gazdagok;
        }
        static void Main(string[] args)
        {
            var dolgozok = new List<Dolgozo>();
            using var sr = new StreamReader(@"..\..\..\src\adatok.txt");
            while (!sr.EndOfStream)
            {
                dolgozok.Add(new Dolgozo(sr.ReadLine()));
            }

            foreach (var item in dolgozok)
            {
                Console.WriteLine(item);
            }

            //Függvény segítségével írd ki az életkorok átlagát.

            Console.WriteLine("8.feladat:");
            var atlag = dolgozok.Average(d => d.Age);
            Console.WriteLine($"A dolgozók átlag életkora: {atlag}");

            //Függvény segítségével írd ki azon személyek számát, akiknek a városa 'Budapest'.

            Console.WriteLine("\n9.feladat:");
            var pestiek = dolgozok.Count(d => d.City == "Budapest");
            Console.WriteLine($"Pesti emberek száma: {pestiek}");

            //Függvény segítségével keresd ki, majd a virtuális metódus segítségével írd ki a legidősebb személy adatait.

            Console.WriteLine("\n10.feladat:");
            var legidosebb = dolgozok.Where(d => d.Age == dolgozok.Max(m => m.Age)).First();
            Console.WriteLine($"Legidősebb személy adatai:");
            Console.WriteLine(legidosebb);

            //Függvény segítségével döntsd el, majd a főprogramban írd ki, hogy van - e 30 év fölötti személy, és emellett írd ki a nevét is.

            Console.WriteLine("\n11.feladat:");
            var harmincfolottiek = dolgozok.Where(d => d.Age > 30);
            Console.WriteLine($"30 fölöttiek nevei: ");
            foreach (var item in harmincfolottiek)
            {
                Console.Write($"{item.Name},");
            }

            //Függvénnyel válogasd ki azon személyek nevét egy új tömbbe(nem listába), akik 30 évnél fiatalabbak. Ennek a tömbnek a hasznos tartalmát írd ki a főprogramban.

            Console.WriteLine("\n12.feladat:");
            string[] harmincalattiaktomb = new string[dolgozok.Count];
            for (int i = 0; i < harmincalattiaktomb.Length; i++)
            {
                if (dolgozok[i].Age < 30)
                {
                    harmincalattiaktomb[i] = dolgozok[i].Name;
                }
            }
            var kiszedes = harmincalattiaktomb.Where(d => !string.IsNullOrEmpty(d)).ToArray();

            foreach (var item in kiszedes)
            {
                Console.WriteLine(item);
            }

            //Készíts egy függvényt, ami átszámolja az euróban megadott havi fizetést éves fizetéssé, és az eredményt még váltsd át magyar forintba is.

            Console.WriteLine("\n15.feladat:");
            var gazdagok = Gazdagok(dolgozok);
            using var sw = new StreamWriter(@"..\..\..\src\kiiras.txt");
            foreach (var item in gazdagok)
            {
                sw.WriteLine(item);
            }

            Console.WriteLine("\n16.feladat:");
            var averageSalary = dolgozok.Average(d => d.Salary);
            Console.WriteLine($"Átlagfizetés: {averageSalary:0} euró");

            Console.WriteLine("\n17.feladat: ");
            var developerekatlagfizetes = dolgozok.Where(d => d.Position == "Developer").Average(a => a.Salary);
            Console.WriteLine($"Developerek átlagfizetése: {developerekatlagfizetes} euró");

            Console.WriteLine("\n18.feladat: ");
            var noiatlag = dolgozok.Where(d => !d.Gender).Average(a => a.Salary);
            var ferfiatlag = dolgozok.Where(d => d.Gender).Average(a => a.Salary);
            Console.WriteLine($"A női átlag fizetés: {noiatlag} euró");
            Console.WriteLine($"A férfi átlag fizetés: {ferfiatlag} euró");


        }
    }
}
