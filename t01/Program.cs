namespace t01;

class Program
{
    static void Main(string[] args)
    {
        OmaTietue tietue = new OmaTietue();

        Console.Write("Anna luku1: ");
        tietue.luku1 = int.Parse(Console.ReadLine());

        Console.Write("Anna luku2: ");
        tietue.luku2 = int.Parse(Console.ReadLine());

        Tulosta(tietue);
    }
    static void Tulosta(OmaTietue x)
    {
        Console.WriteLine($"Lukujen summa: {x.luku1 + x.luku2}");
    }
}
