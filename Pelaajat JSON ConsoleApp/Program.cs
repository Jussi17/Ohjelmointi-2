using System.Text.Json;

namespace t19
{
    class Program
    {
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        public struct Pelaaja
        {
            public string Nimi { get; set; }
            public double Pisteet { get; set; }

            public Pelaaja(string nimi, double pisteet)
            {
                Nimi = nimi;
                Pisteet = pisteet;
            }
        }

        private static void Main()
        {
            List<Pelaaja> pelaajat = [];

            while (true)
            {
                Console.Write("Nimi: ");
                string? nimi = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nimi))
                    break;

                Console.Write("Pisteet: ");
                if (double.TryParse(Console.ReadLine(), out double pisteet))
                {
                    pelaajat.Add(new Pelaaja(nimi, pisteet));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Virheelliset pisteet, yritä uudestaan!");
                }
            }

            string json = JsonSerializer.Serialize(pelaajat, JsonOptions);
            File.WriteAllText("pelaajat.json", json);

            Console.WriteLine("Tiedot tallennettu pelaajat.json -tiedostoon.");
        }
    }
}
