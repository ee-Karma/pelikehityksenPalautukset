using System;

public struct Koordinaatti
{
    public int X { get; }
    public int Y { get; }

    public Koordinaatti(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool OnkoVieressa(Koordinaatti toinen)
    {
        return (Math.Abs(X - toinen.X) == 1 && Y == toinen.Y) || (Math.Abs(Y - toinen.Y) == 1 && X == toinen.X);
    }
}

class Program
{
    static void Main()
    {
        Koordinaatti koord1 = new Koordinaatti(1, 2);
        Koordinaatti koord2 = new Koordinaatti(2, 2);
        Koordinaatti koord3 = new Koordinaatti(1, 3);
        Koordinaatti koord4 = new Koordinaatti(3, 3);

        Console.WriteLine($"Koordinaatti {koord1.X}, {koord1.Y} ja {koord2.X}, {koord2.Y} ovat vieressä: {koord1.OnkoVieressa(koord2)}");
        Console.WriteLine($"Koordinaatti {koord1.X}, {koord1.Y} ja {koord3.X}, {koord3.Y} ovat vieressä: {koord1.OnkoVieressa(koord3)}");
        Console.WriteLine($"Koordinaatti {koord1.X}, {koord1.Y} ja {koord4.X}, {koord4.Y} ovat vieressä: {koord1.OnkoVieressa(koord4)}");
    }
}