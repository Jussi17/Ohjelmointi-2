using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace t09
{
    public partial class MainPage : ContentPage
    {
        private Random _random = new Random();

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnPageClicked(object sender, EventArgs e)
        {
            if(BackgroundColor != Colors.Red)
            {
                BackgroundColor = Colors.Red;
            }
            else
            {
                BackgroundColor = RandomColor();
            }
        }

        private Color RandomColor()
        {
            return Color.FromRgb(_random.Next(256), _random.Next(256), _random.Next(256));
        }
    }
}