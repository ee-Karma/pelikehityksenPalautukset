using System;

public class Tavara
{
    public virtual string Nimi => "Tuntematon Tavara";
}

public class Miekka : Tavara
{
    public override string Nimi => "Miekka";
}

public class Kirves : Tavara
{
    public override string Nimi => "Kirves";
}

public class Jousi : Tavara
{
    public override string Nimi => "Jousi";
}

public class VaritettyTavara<T> where T : Tavara
{
    public T Tavara { get; }
    public ConsoleColor Vari { get; }

    public VaritettyTavara(T tavara, ConsoleColor vari)
    {
        Tavara = tavara;
        Vari = vari;
    }

    public void NaytaTavara()
    {
        Console.ForegroundColor = Vari;
        Console.WriteLine(Tavara.Nimi);
        Console.ResetColor();
    }
}

class Program
{
    static void Main()
    {
        Miekka testiMiekka = new Miekka();
        VaritettyTavara<Miekka> tulimiekka = new VaritettyTavara<Miekka>(testiMiekka, ConsoleColor.Blue); 
        tulimiekka.NaytaTavara();

        Jousi testiJousi = new Jousi();
        VaritettyTavara<Jousi> tulijousi = new VaritettyTavara<Jousi>(testiJousi, ConsoleColor.Red); 
        tulijousi.NaytaTavara();

        Kirves testiKirves = new Kirves();
        VaritettyTavara<Kirves> tulikirves = new VaritettyTavara<Kirves>(testiKirves, ConsoleColor.Green); 
        tulikirves.NaytaTavara();
    }
}