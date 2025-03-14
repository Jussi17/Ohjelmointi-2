using System;
using System.IO;
using CommunityToolkit.Maui.Storage;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace t18
{
    public partial class MainPage : ContentPage
    {
        private string filePath;

        public MainPage()
        {
            InitializeComponent();
            filePath = Path.Combine(FileSystem.CacheDirectory, "teksti_tiedosto.txt");
        }

        private void NewFile(object sender, EventArgs e)
        {
            Editori.Text = "";
            FilePathLabel.Text = "Ei tiedostoa valittuna";
        }

        private async void OpenFile(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {

                    FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                        { DevicePlatform.WinUI, new[] { ".txt" } }
                    })
                });

                if (result != null)
                {
                    if (result.FileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = await result.OpenReadAsync();
                        using var reader = new StreamReader(stream);
                        Editori.Text = await reader.ReadToEndAsync();
                        FilePathLabel.Text = result.FullPath;
                    }
                    else
                    {
                        await DisplayAlert("Virhe", "Väärä tiedostotyyppi", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Virhe", ex.Message, "OK");
            }
        }

        private void SaveFile(object sender, EventArgs e)
        {
            using (StreamWriter writer = new(filePath, false))
            {
                writer.Write(Editori.Text);
            }

            DisplayAlert("Tallennus", "Teksti tallennettu onnistuneesti.", "OK");
        }

        private async void SaveNameFile(object sender, EventArgs e)
        {
            try
            {
                var result = await FileSaver.SaveAsync(filePath,
                    new MemoryStream(System.Text.Encoding.UTF8.GetBytes(Editori.Text)));

                if (result.IsSuccessful) 
                {
                    await DisplayAlert("Tallennus", "Teksti tallennettu onnistuneesti.", "OK");
                }
                else
                {
                    await DisplayAlert("Virhe", "Tallennus epäonnistui", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Virhe", ex.Message, "OK");
            }
        }
        private void ExitApp(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
