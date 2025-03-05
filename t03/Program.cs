namespace t03;

public struct ToinenAste
{
    public double a, b, c;

    public Ratkaisu Ratkaise()
    {
        var kertoimet = b * b - 4 * a * c;
        if (kertoimet < 0)
        {
            throw new InvalidOperationException("Ei reaalilukuratkaisuja.");
        }
        var sqrtD = Math.Sqrt(kertoimet);
        var x1 = (-b + sqrtD) / (2 * a);
        var x2 = (-b - sqrtD) / (2 * a);
        return new Ratkaisu { x1 = x1, x2 = x2 };
    }
}

public struct Ratkaisu
{
    public double x1, x2;
}

class Program
{
    static void Main()
    {
        double a = 0, b = 0, c = 0;
        bool validInput = false;

        while (!validInput)
        {
            try
            {
                Console.Write("Anna kerroin a: ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Anna kerroin b: ");
                b = double.Parse(Console.ReadLine());
                Console.Write("Anna kerroin c: ");
                c = double.Parse(Console.ReadLine());

                ToinenAste yhtalo = new ToinenAste { a = a, b = b, c = c };
                Ratkaisu ratkaisut = yhtalo.Ratkaise();

                Console.WriteLine($"Ratkaisut: x1 = {ratkaisut.x1}, x2 = {ratkaisut.x2}");
                validInput = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Virheellinen syöte, syötä numerot.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}