using Microsoft.Maui.Controls;

namespace t17
{
    public partial class MainPage : ContentPage
    {
        private string filePath;

        public MainPage()
        {
            InitializeComponent();
            filePath = Path.Combine(FileSystem.CacheDirectory, "tekstitiedosto.txt");
        }

        private async void ReadFile(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                using StreamReader reader = new(filePath);
                Editori.Text = await reader.ReadToEndAsync();
            }
            else
            {
                await DisplayAlert("Virhe", "Tiedostoa ei löydy!", "OK");
            }
        }

        private async void SaveFile(object sender, EventArgs e)
        {
            using (StreamWriter writer = new(filePath, false))
            {
                await writer.WriteAsync(Editori.Text);
            }
            await DisplayAlert("Tallennus", "Teksti tallennettu onnistuneesti.", "OK");
        }

        private void ExitApp(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}