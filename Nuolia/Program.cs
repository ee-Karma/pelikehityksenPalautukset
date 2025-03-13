using System;

namespace Roolipeli
{
    public enum KarkiTyyppi
    {
        Puu,
        Teras,
        Timantti
    }

    public enum PeraTyyppi
    {
        Lehti,
        Kanansulka,
        Kotkansulka
    }

    public class Nuoli
    {
        public KarkiTyyppi Karki { get; set; }
        public PeraTyyppi Pera { get; set; }
        public int Pituus { get; set; }

        public Nuoli(KarkiTyyppi karki, PeraTyyppi pera, int pituus)
        {
            Karki = karki;
            Pera = pera;
            Pituus = pituus;
        }

        public double PalautaHinta()
        {
            double karkiHinta = 0;
            double peraHinta = 0;
            double varsiHinta = 0;

            switch (Karki)
            {
                case KarkiTyyppi.Puu:
                    karkiHinta = 3;
                    break;
                case KarkiTyyppi.Teras:
                    karkiHinta = 5;
                    break;
                case KarkiTyyppi.Timantti:
                    karkiHinta = 50;
                    break;
            }

            switch (Pera)
            {
                case PeraTyyppi.Lehti:
                    peraHinta = 0;
                    break;
                case PeraTyyppi.Kanansulka:
                    peraHinta = 1;
                    break;
                case PeraTyyppi.Kotkansulka:
                    peraHinta = 5;
                    break;
            }

            varsiHinta = Pituus * 0.05;

            return karkiHinta + peraHinta + varsiHinta;
        }

        public static Nuoli LuoEliittiNuoli()
        {
            return new Nuoli(KarkiTyyppi.Timantti, PeraTyyppi.Kotkansulka, 100);
        }

        public static Nuoli LuoAloittelijanuoli()
        {
            return new Nuoli(KarkiTyyppi.Puu, PeraTyyppi.Kanansulka, 70);
        }

        public static Nuoli LuoPerusnuoli()
        {
            return new Nuoli(KarkiTyyppi.Teras, PeraTyyppi.Kanansulka, 85);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervetuloa nuolikauppaan.");
            Console.WriteLine("Haluatko:");
            Console.WriteLine("1. Teettää nuolen tilaustyönä?");
            Console.WriteLine("2. Ostaa valmiin nuolen?");
            Console.Write("Valinta: ");
            int valinta = int.Parse(Console.ReadLine());

            if (valinta == 2)
            {
                Console.WriteLine("\nValitse valmis nuoli:");
                Console.WriteLine("1. Eliittinuoli");
                Console.WriteLine("2. Aloittelijanuoli");
                Console.WriteLine("3. Perusnuoli");
                Console.Write("Valinta: ");
                int nuoliValinta = int.Parse(Console.ReadLine());

                Nuoli valittuNuoli = null;

                switch (nuoliValinta)
                {
                    case 1:
                        valittuNuoli = Nuoli.LuoEliittiNuoli();
                        break;
                    case 2:
                        valittuNuoli = Nuoli.LuoAloittelijanuoli();
                        break;
                    case 3:
                        valittuNuoli = Nuoli.LuoPerusnuoli();
                        break;
                    default:
                        Console.WriteLine("Virheellinen valinta.");
                        return;
                }

                double hinta = valittuNuoli.PalautaHinta();
                Console.WriteLine($"\nValitsemasi nuolen hinta on {hinta} kultarahaa.");
            }
            else if (valinta == 1)
            {
                Console.WriteLine("\nValitse nuolen kärki (puu, teräs, timantti):");
                string karkiValinta = Console.ReadLine();
                KarkiTyyppi karki = (KarkiTyyppi)Enum.Parse(typeof(KarkiTyyppi), karkiValinta, true);

                Console.WriteLine("Valitse nuolen perä (lehti, kanansulka, kotkansulka):");
                string peraValinta = Console.ReadLine();
                PeraTyyppi pera = (PeraTyyppi)Enum.Parse(typeof(PeraTyyppi), peraValinta, true);

                Console.WriteLine("Nuolen pituus sentteinä (60-100):");
                int pituus = int.Parse(Console.ReadLine());

                Nuoli nuoli = new Nuoli(karki, pera, pituus);
                double hinta = nuoli.PalautaHinta();

                Console.WriteLine($"\nTämän nuolen hinta on {hinta} kultarahaa.");
            }
            else
            {
                Console.WriteLine("Virheellinen valinta.");
            }
        }
    }
}