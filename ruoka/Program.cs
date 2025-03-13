using System;
using System.Collections.Generic;

namespace RavintolaSovellus
{
    public enum PaaRaakaAine
    {
        Nautaa,
        Kanaa,
        Kasviksia
    }

    public enum Lisuke
    {
        Perunaa,
        Riisia,
        Pastaa
    }

    public enum Kastike
    {
        Curry,
        Hapanimela,
        Pippuri,
        Chili
    }

    public class Ateria
    {
        public PaaRaakaAine PaaRaakaAine { get; set; }
        public Lisuke Lisuke { get; set; }
        public Kastike Kastike { get; set; }

        public override string ToString()
        {
            return $"{PaaRaakaAine.ToString().ToLower()} ja {Lisuke.ToString().ToLower()} {Kastike.ToString().ToLower()} kastikkeella.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Ateria> valitutAteriat = new List<Ateria>();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Valitse ruoka-annos {i + 1}:");

                Console.WriteLine("Pääraaka-aine (nautaa, kanaa, kasviksia): ");
                PaaRaakaAine paaRaakaAine = (PaaRaakaAine)Enum.Parse(typeof(PaaRaakaAine), Console.ReadLine(), true);

                Console.WriteLine("Lisukkeet (perunaa, riisia, pastaa): ");
                Lisuke lisuke = (Lisuke)Enum.Parse(typeof(Lisuke), Console.ReadLine(), true);

                Console.WriteLine("Kastike (pippuri, chili, hapanimela, curry): ");
                Kastike kastike = (Kastike)Enum.Parse(typeof(Kastike), Console.ReadLine(), true);

                Ateria ateria = new Ateria
                {
                    PaaRaakaAine = paaRaakaAine,
                    Lisuke = lisuke,
                    Kastike = kastike
                };
                valitutAteriat.Add(ateria);
            }

            Console.WriteLine("\nValitut ruoka-annokset:");
            foreach (var ateria in valitutAteriat)
            {
                Console.WriteLine(ateria);
            }
        }
    }
}