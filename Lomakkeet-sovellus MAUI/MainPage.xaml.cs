using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Maui.Controls;

namespace t11
{
    public partial class MainPage : ContentPage
    {
        private Person? _person;

        public MainPage()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<SavePersonMessage>(this, (r, message) =>
            {
                _person = message.Value;
                UpdateLabels();
            });

            WeakReferenceMessenger.Default.Register<LoadPersonMessage>(this, (r, message) =>
            {
                if (_person != null)
                {
                    WeakReferenceMessenger.Default.Send(new LoadPersonDataMessage(_person));
                }
            });
        }

        private async void EditorButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditorPage());
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            Application.Current?.Quit();
        }

        private void UpdateLabels()
        {
            if (_person != null)
            {
                NameLabel.Text = _person.Name;
                AddressLabel.Text = _person.Address;
                PhoneLabel.Text = _person.Phone;
                EmailLabel.Text = _person.Email;
            }
        }
    }

    public class SavePersonMessage(Person person) : ValueChangedMessage<Person>(person)
    {
    }

    public class LoadPersonMessage : RequestMessage<Person> { }

    public class LoadPersonDataMessage(Person person) : ValueChangedMessage<Person>(person)
    {
    }

    public record Person(string Name, string Address, string Phone, string Email) : IEquatable<Person>;

}

