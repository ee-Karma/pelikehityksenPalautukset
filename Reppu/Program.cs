using System;
using System.Collections.Generic;

namespace Roolipeli
{
    public class Tavara
    {
        public double Paino { get; set; }
        public double Tilavuus { get; set; }

        public Tavara(double paino, double tilavuus)
        {
            Paino = paino;
            Tilavuus = tilavuus;
        }

        public override string ToString()
        {
            return "Tavara";
        }
    }

    public class Nuoli : Tavara
    {
        public Nuoli() : base(0.1, 0.05) { }

        public override string ToString()
        {
            return "Nuoli";
        }
    }

    public class Jousi : Tavara
    {
        public Jousi() : base(1, 4) { }

        public override string ToString()
        {
            return "Jousi";
        }
    }

    public class Koeysi : Tavara
    {
        public Koeysi() : base(1, 1.5) { }

        public override string ToString()
        {
            return "Köysi";
        }
    }

    public class Vesi : Tavara
    {
        public Vesi() : base(2, 2) { }

        public override string ToString()
        {
            return "Vesi";
        }
    }

    public class RuokaAnnos : Tavara
    {
        public RuokaAnnos() : base(1, 0.5) { }

        public override string ToString()
        {
            return "Ruoka-annos";
        }
    }

    public class Miekka : Tavara
    {
        public Miekka() : base(5, 3) { }

        public override string ToString()
        {
            return "Miekka";
        }
    }

    public class Reppu
    {
        public int MaxTavaroidenMaara { get; set; }
        public double MaxKantoPaino { get; set; }
        public double MaxTilavuus { get; set; }

        private List<Tavara> tavarat;

        public Reppu(int maxTavaroidenMaara, double maxKantoPaino, double maxTilavuus)
        {
            MaxTavaroidenMaara = maxTavaroidenMaara;
            MaxKantoPaino = maxKantoPaino;
            MaxTilavuus = maxTilavuus;
            tavarat = new List<Tavara>();
        }

        public bool Lisaa(Tavara tavara)
        {
            if (tavarat.Count >= MaxTavaroidenMaara ||
                TavaroidenPaino() + tavara.Paino > MaxKantoPaino ||
                TavaroidenTilavuus() + tavara.Tilavuus > MaxTilavuus)
            {
                return false;
            }
            tavarat.Add(tavara);
            return true;
        }

        public int TavaroidenMaara() => tavarat.Count;

        public double TavaroidenPaino()
        {
            double paino = 0;
            foreach (var tavara in tavarat)
            {
                paino += tavara.Paino;
            }
            return paino;
        }

        public double TavaroidenTilavuus()
        {
            double tilavuus = 0;
            foreach (var tavara in tavarat)
            {
                tilavuus += tavara.Tilavuus;
            }
            return tilavuus;
        }

        public void NaytaKapasiteetti()
        {
            Console.WriteLine($"Tavaroiden määrä: {TavaroidenMaara()}/{MaxTavaroidenMaara}");
            Console.WriteLine($"Kanto paino: {TavaroidenPaino()}/{MaxKantoPaino}");
            Console.WriteLine($"Tilavuus: {TavaroidenTilavuus()}/{MaxTilavuus}");
        }

        public override string ToString()
        {
            if (tavarat.Count == 0)
            {
                return "Reppu on tyhjä.";
            }

            string sisalto = "Reppussa on seuraavat tavarat: ";
            for (int i = 0; i < tavarat.Count; i++)
            {
                sisalto += tavarat[i].ToString();
                if (i < tavarat.Count - 1)
                {
                    sisalto += ", ";
                }
            }
            return sisalto;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Reppu reppu = new Reppu(5, 10, 5);
            Console.WriteLine(reppu.ToString());

            bool jatka = true;

            while (jatka)
            {
                Console.WriteLine("Valitse toiminto:");
                Console.WriteLine("1. Lisää nuoli");
                Console.WriteLine("2. Lisää jousi");
                Console.WriteLine("3. Lisää köysi");
                Console.WriteLine("4. Lisää vesi");
                Console.WriteLine("5. Lisää ruoka-annos");
                Console.WriteLine("6. Lisää miekka");
                Console.WriteLine("7. Näytä repun kapasiteetti");
                Console.WriteLine("8. Lopeta");
                Console.Write("Valinta: ");
                int valinta = int.Parse(Console.ReadLine());

                switch (valinta)
                {
                    case 1:
                        if (reppu.Lisaa(new Nuoli()))
                            Console.WriteLine("Nuoli lisätty reppuun.");
                        else
                            Console.WriteLine("Reppu täynnä, nuoli ei lisätty.");
                        break;
                    case 2:
                        if (reppu.Lisaa(new Jousi()))
                            Console.WriteLine("Jousi lisätty reppuun.");
                        else
                            Console.WriteLine("Reppu täynnä, jousi ei lisätty.");
                        break;
                    case 3:
                        if (reppu.Lisaa(new Koeysi()))
                            Console.WriteLine("Köysi lisätty reppuun.");
                        else
                            Console.WriteLine("Reppu täynnä, köysi ei lisätty.");
                        break;
                    case 4:
                        if (reppu.Lisaa(new Vesi()))
                            Console.WriteLine("Vesi lisätty reppuun.");
                        else
                            Console.WriteLine("Reppu täynnä, vesi ei lisätty.");
                        break;
                    case 5:
                        if (reppu.Lisaa(new RuokaAnnos()))
                            Console.WriteLine("Ruoka-annos lisätty reppuun.");
                        else
                            Console.WriteLine("Reppu täynnä, ruoka-annos ei lisätty.");
                        break;
                    case 6:
                        if (reppu.Lisaa(new Miekka()))
                            Console.WriteLine("Miekka lisätty reppuun.");
                        else
                            Console.WriteLine("Reppu täynnä, miekka ei lisätty.");
                        break;
                    case 7:
                        reppu.NaytaKapasiteetti();
                        break;
                    case 8:
                        jatka = false;
                        break;
                    default:
                        Console.WriteLine("Virheellinen valinta.");
                        break;
                }

                Console.WriteLine(reppu.ToString());
            }
        }
    }
}