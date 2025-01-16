using System.Security.Cryptography;

namespace Olio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int ritariHP = 15;
            int orcHp = 15;
            // Näytä tilanne
            Console.WriteLine($"Ritarin HP: {ritariHP}" +$" Örkin HP: {orcHp}");
            // Näytä komennot
            // 1. Hyökkää 2. Puolusta
            Console.WriteLine("1. hyökkää 2. puolusta");
            // While luuppi
            while(true)
            {

            // kysy komento
            // tallenna vastaus
            string? vastaus = Console.ReadLine();
            
            // jos vastaus on 1 tai 2 hyväksy vastaus
            if (vastaus == "1")
                {
                    int damage = Random.Next(5, 15);

                    orcHp -= rand1;
                    Console.WriteLine($"Teit {rand1} vahinkopistettä Öröllä on nyt {orcHp} terveyspisteitä");


                    break;
                }
            else if (vastaus == "2")
                {

                    break;
                }
                else { Console.WriteLine("Vastaa 1. jos haluat hyökätä ja 2 jos haluat puolustaa"); }
                
            }

            Random rng = new Random();

            int rand2 = rng.Next(2);

            if(rand2 == 0) { }




            // jos jotain muuta kysy uudestaan
        }
    }
}
