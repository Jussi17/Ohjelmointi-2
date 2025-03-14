using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace t08
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnOpenClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Valitse kuvatiedosto",
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    using var stream = await result.OpenReadAsync();
                    var memoryStream = new MemoryStream();
                    await stream.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    SelectedImage.Source = ImageSource.FromStream(() => memoryStream);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Virhe", $"Kuvan valinta epäonnistui: {ex.Message}", "OK");
            }
        }
    }
}