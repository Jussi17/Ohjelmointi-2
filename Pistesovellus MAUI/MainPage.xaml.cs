using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace t20
{
    public partial class MainPage : ContentPage
    {
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
        private List<PelaajaViewModel> pelaajaViewModels = [];
        private string? currentFilePath;
        private bool isEvenRow = true;

        public class PelaajaViewModel
        {
            public string Nimi { get; set; }
            public double Pisteet { get; set; }
            public Color RowColor { get; set; }

            public PelaajaViewModel(string nimi, double pisteet, Color rowColor)
            {
                Nimi = nimi;
                Pisteet = pisteet;
                RowColor = rowColor;
            }
        }

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

        public MainPage()
        {
            InitializeComponent();
            UpdateBorderVisibility();
        }

        private async void OnOpenClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                        { DevicePlatform.WinUI, new[] { ".json" } }
                    })
                });

                if (result != null && result.FileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                {
                    currentFilePath = result.FullPath;
                    using var stream = await result.OpenReadAsync();
                    using var reader = new StreamReader(stream);
                    string json = await reader.ReadToEndAsync();

                    var loadedPelaajat = JsonSerializer.Deserialize<List<Pelaaja>>(json, JsonOptions) ?? new List<Pelaaja>();

                    pelaajaViewModels.Clear();
                    isEvenRow = true;
                    foreach (var pelaaja in loadedPelaajat)
                    {
                        Color rowColor = isEvenRow ? Colors.LightGreen : Colors.Cornsilk;
                        pelaajaViewModels.Add(new PelaajaViewModel(pelaaja.Nimi, pelaaja.Pisteet, rowColor));
                        isEvenRow = !isEvenRow;
                    }

                    PlayerListView.ItemsSource = pelaajaViewModels;
                    UpdateBorderVisibility();
                }
                else
                {
                    await DisplayAlert("Virhe", "Väärä tiedostotyyppi", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Virhe", ex.Message, "OK");
            }
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NimiEntry.Text) || !double.TryParse(PisteetEntry.Text, out double pisteet))
            {
                await DisplayAlert("Virhe", "Virheelliset tiedot!", "OK");
                return;
            }

            if (currentFilePath == null)
            {
                await DisplayAlert("Virhe", "Avaa ensin tiedosto!", "OK");
                return;
            }

            Color rowColor = isEvenRow ? Colors.LightGreen : Colors.Cornsilk;
            pelaajaViewModels.Add(new PelaajaViewModel(NimiEntry.Text, pisteet, rowColor));
            isEvenRow = !isEvenRow;

            PlayerListView.ItemsSource = null;
            PlayerListView.ItemsSource = pelaajaViewModels;

            NimiEntry.Text = string.Empty;
            PisteetEntry.Text = string.Empty;

            UpdateBorderVisibility();

            try
            {
                var pelaajatToSave = pelaajaViewModels.Select(vm => new Pelaaja(vm.Nimi, vm.Pisteet)).ToList();
                string json = JsonSerializer.Serialize(pelaajatToSave, JsonOptions);
                await File.WriteAllTextAsync(currentFilePath, json);
                await DisplayAlert("Tallennus", "Tiedot tallennettu!", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Virhe", $"Tallennusvirhe: {ex.Message}", "OK");
            }
        }

        private void UpdateBorderVisibility()
        {
            Border.IsVisible = pelaajaViewModels.Count > 0;
        }
    }
}