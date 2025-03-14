namespace t16
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCheckDateClicked(object sender, EventArgs e)
        {
            string paiva = Paiva.Text;
            string kk = Kuukausi.Text;
            string vuosi = Vuosi.Text;

            try
            {
                bool isValid = CheckDate(paiva, kk, vuosi);
                if (isValid)
                {
                    DisplayAlert("Tarkistus", "Päivämäärä on oikein", "OK");
                }
            }
            catch (ArgumentNullException ex)
            {
                DisplayAlert("Virhe", ex.Message, "OK");
            }
            catch (FormatException ex)
            {
                DisplayAlert("Virhe", ex.Message, "OK");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                DisplayAlert("Virhe", ex.Message, "OK");
            }
            catch (Exception)
            {
                DisplayAlert("Virhe", "Virheellinen päivämäärä", "OK");
            }
        }

        private static bool CheckDate(string day, string month, string year)
        {
            if (string.IsNullOrWhiteSpace(day))
                throw new ArgumentNullException(nameof(day), "Päivä puuttuu");
            if (string.IsNullOrWhiteSpace(month))
                throw new ArgumentNullException(nameof(month), "Kuukausi puuttuu");
            if (string.IsNullOrWhiteSpace(year))
                throw new ArgumentNullException(nameof(year), "Vuosi puuttuu");

            if (!int.TryParse(day, out int pv))
                throw new FormatException("Anna päivä numerona");
            if (!int.TryParse(month, out int k))
                throw new FormatException("Anna kuukausi numerona");
            if (!int.TryParse(year, out int v))
                throw new FormatException("Anna vuosi numerona");

            if (pv <= 0)
                throw new ArgumentOutOfRangeException(nameof(day), "Päivä on liian pieni");
            if (pv >= 32)
                throw new ArgumentOutOfRangeException(nameof(day), "Päivä on suuri");
            if (k <= 0)
                throw new ArgumentOutOfRangeException(nameof(month), "Kuukausi on liian pieni");
            if (k >= 13)
                throw new ArgumentOutOfRangeException(nameof(month), "Kuukausi on liian suuri");
            if (v <= 0)
                throw new ArgumentOutOfRangeException(nameof(year), "Vuosi on liian pieni");
            if (v >= 3001)
                throw new ArgumentOutOfRangeException(nameof(year), "Vuosi on liian suuri");

            return true;
        }
    }
}
