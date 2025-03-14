namespace t02
{
    public struct TiedotTietue
    {
        public string etuNimi;
        public string sukuNimi;
        public int ika;

        public TiedotTietue(string etunimi, string sukunimi, int ikaa)
        {
            etuNimi = etunimi;
            sukuNimi = sukunimi;
            ika = ikaa;
        }

        public static TiedotTietue[] Henkilotiedot()
        {
            return new TiedotTietue[10]
            {
                new TiedotTietue("Matti", "Meikalainen", 75),
                new TiedotTietue("Maija", "Suomalainen", 73),
                new TiedotTietue("Mikko", "Mallikas", 29),
                new TiedotTietue("Maija", "Mallila", 28),
                new TiedotTietue("Pekka", "Poutanen", 45),
                new TiedotTietue("Jukka", "Kirahvinen", 48),
                new TiedotTietue("Mervi", "Korhonen", 33),
                new TiedotTietue("Simo", "Pasanen", 39),
                new TiedotTietue("Sirpa", "Lapsela", 9),
                new TiedotTietue("Viivi", "Virtanen", 19)
            };
        }
    }
}
