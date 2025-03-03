namespace t02
{
    class Program
    {
        static void Main(string[] args)
        {
            TiedotTietue[] tiedot = TiedotTietue.Henkilotiedot();
            LaskeKeskiIka(tiedot);
        }

        static void LaskeKeskiIka(TiedotTietue[] ihmiset)
        {
            int summa = 0;
            for (int i = 0; i < ihmiset.Length; i++)
            {
                summa += ihmiset[i].ika;
            }
            double keskiIka = (double)summa / ihmiset.Length;
            Console.WriteLine($"Henkilöiden keski-ikä: {keskiIka}");
        }
    }
}
