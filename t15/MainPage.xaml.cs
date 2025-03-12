using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;

namespace t15
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnEntryUnfocused(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;
            if (entry == null) return;

            try
            {
                entry.BackgroundColor = Colors.Transparent;
                ToolTipProperties.SetText(entry, string.Empty);

                if (string.IsNullOrWhiteSpace(entry.Text))
                {
                    SetErrorState(entry);
                    return;
                }

                int result = int.Parse(entry.Text);
            }
            catch (FormatException)
            {
                SetErrorState(entry);
            }
            catch (OverflowException)
            {
                SetErrorState(entry);
            }
        }

        private void SetErrorState(Entry entry)
        {
            entry.BackgroundColor = Colors.Red;
            ToolTipProperties.SetText(entry, "Virheellinen syöte");
            entry.Focus();
        }
    }
}