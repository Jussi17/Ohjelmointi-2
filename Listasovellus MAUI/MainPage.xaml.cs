using System.Collections.ObjectModel;

namespace t12
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<PersonInfo> Persons { get; set; } = [];

        public MainPage()
        {
            InitializeComponent();
            PersonListView.ItemsSource = Persons;
            UpdateBorderVisibility();
            Persons.CollectionChanged += (s, e) => UpdateBorderVisibility();
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
                string.IsNullOrWhiteSpace(AddressEntry.Text) ||
                string.IsNullOrWhiteSpace(PhoneEntry.Text) ||
                string.IsNullOrWhiteSpace(EmailEntry.Text))
            {
                DisplayAlert("Virhe", "Kaikki kentät on täytettävä.", "OK");
                return;
            }

            var person = new PersonInfo
            {
                Name = NameEntry.Text,
                Address = AddressEntry.Text,
                Phone = PhoneEntry.Text,
                Email = EmailEntry.Text
            };

            Persons.Add(person);

            NameEntry.Text = string.Empty;
            AddressEntry.Text = string.Empty;
            PhoneEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is PersonInfo selectedPerson)
            {
                NameEntry.Text = selectedPerson.Name;
                AddressEntry.Text = selectedPerson.Address;
                PhoneEntry.Text = selectedPerson.Phone;
                EmailEntry.Text = selectedPerson.Email;

                Persons.Remove(selectedPerson);
                PersonListView.SelectedItem = null;
            }
        }

        private void UpdateBorderVisibility()
        {
            Border.IsVisible = Persons.Count > 0;
        }
    }
}


