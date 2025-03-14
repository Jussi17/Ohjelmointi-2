namespace t13;

class Program
{
    private static void Main()
    {
        OmaTietue tietue = new()
        {
            luku1 = IntLuku("Anna luku1: "),
            luku2 = IntLuku("Anna luku2: ")
        };

        Tulosta(tietue);
    }

    private static int IntLuku(string kysymys)
    {
        int tulos;
        while (true)
        {
            Console.Write(kysymys);
            string? input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Virheellinen syöte. Anna kokonaisluku.");
                continue;
            }
            try
            {
                tulos = int.Parse(input);
                break;
            }
            catch (FormatException f)
            {
                Console.WriteLine("Virheellinen syöte. Anna kokonaisluku.");
                Console.WriteLine(f.Message);
            }
        }
        return tulos;
    }

    private static void Tulosta(OmaTietue x)
    {
        Console.WriteLine($"Lukujen summa: {x.luku1 + x.luku2}");
    }

    public struct OmaTietue
    {
        public int luku1, luku2;
    }
}