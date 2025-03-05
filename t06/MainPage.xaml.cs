namespace t06
{
    public partial class MainPage : ContentPage
    {
        float count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            if (count == 0)
            {
                count = 2;
                EntryField.Text = $"{count}";
            }

            else
            {
                count = count * 2;
                EntryField.Text = $"{count}";
            }

            SemanticScreenReader.Announce(EntryField.Text);
        }
    }

}
