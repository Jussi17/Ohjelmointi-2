namespace t14;

class Program
{
    private static void Main()
    {
        int x = 0, y = 0;
        bool validInput = false;

        while (!validInput)
        {
            try
            {
                Console.Write("Anna kokonaisluku x: ");
                x = int.Parse(Console.ReadLine());
                Console.Write("Anna kokonaisluku y: ");
                y = int.Parse(Console.ReadLine());

                validInput = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Virhe: Syötteen täytyy olla kokonaisluku. Yritä uudelleen.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Odottamaton virhe: {ex.Message}. Yritä uudelleen.");
            }
        }

        try
        {
            Potenssi(x, y);
            Jako(x, y);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Virhe: Nollalla jakaminen ei ole sallittua.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Odottamaton virhe: {ex.Message}");
        }
    }

    private static void Potenssi(int a, int b)
    {
        try
        {
            var potenssiLasku = Math.Pow(a, b);
            Console.WriteLine("Potenssi: " + potenssiLasku);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Virhe potenssilaskussa: {ex.Message}");
        }
    }

    private static void Jako(int c, int d)
    {
        try
        {
            var jakoLasku = c / (d * 1.0f);
            Console.WriteLine("Jako: " + jakoLasku);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Virhe: Nollalla jakaminen ei ole sallittua.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Virhe jakolaskussa: {ex.Message}");
        }
    }
}