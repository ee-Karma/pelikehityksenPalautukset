namespace Ovi
{
    internal class Program
    {
        enum OvenTila
        {
            Auki, Suljettu, Lukossa
        }
        enum Toiminto
        {
            Avaa,
            Lukitse,
            AvaaLukko,
            Sulje
        }
        static void Main(string[] args)
        {
            OvenTila tila = OvenTila.Auki;
            string[] toiminnot = Enum.GetNames<Toiminto>();
            Console.WriteLine("Valitse toiminto");
            for (int i = 0; i < toiminnot.Length; i++)
            {
                Console.WriteLine($"{i+1}: {toiminnot[i]}");
            }
            string vastaus = Console.ReadLine();
           
            Toiminto valittu;

            Console.WriteLine($"Ovi on {tila}");

            for (int i = 0; i < toiminnot.Length; i++)
            {
                if (toiminnot[i].ToLower() == vastaus.ToLower())
                {
                    valittu = (Toiminto)i;
                    
                    Console.WriteLine($"Valitsit {valittu}");
                    // Seuraavassa käytetty apua Chat GPT:ltä
                    //Switch tarkistaa mikä toiminto on valittu ja case on periaatteessa if lauseke että jos toiminto oli avaa niin tee näin ja näin kunnes tulee break.
                    switch (valittu)
                    {
                        case Toiminto.Avaa:
                            if (tila == OvenTila.Lukossa || tila == OvenTila.Auki)
                            {
                                Console.WriteLine($"Ovi on {tila} et voi avata sitä.");
                            }
                            else { tila = OvenTila.Auki; Console.WriteLine("Ovi on nyt auki"); }
                            break;

                        case Toiminto.Sulje:
                            if(tila == OvenTila.Lukossa || tila == OvenTila.Suljettu)
                            {
                                Console.WriteLine($"Ovi on {tila} et voi sulkea sitä.");
                            }
                            else { tila = OvenTila.Suljettu; Console.WriteLine("Ovi on nyt suljettu"); }
                            break;
                        case Toiminto.AvaaLukko:
                            if(tila == OvenTila.Suljettu || tila == OvenTila.Auki)
                            {
                                Console.WriteLine($"Oven lukko on auki et voi avata lukkoa");
                            }
                            else { tila = OvenTila.Suljettu; Console.WriteLine("Oven lukko on nyt auki"); }
                            break;
                        case Toiminto.Lukitse:
                            if(tila == OvenTila.Lukossa || tila == OvenTila.Auki)
                            {
                                Console.WriteLine($"Ovi on {tila} et voi lukita sitä");
                            }
                            else { tila = OvenTila.Lukossa; Console.WriteLine("Ovi on nyt lukossa"); }
                            break;

                    }
                }
               
                

            }

            
            
            
        }
    }
}
