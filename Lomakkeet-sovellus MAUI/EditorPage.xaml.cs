using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Maui.Controls;

namespace t11
{
    public partial class EditorPage : ContentPage
    {
        public EditorPage()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<LoadPersonDataMessage>(this, (r, message) =>
            {
                var person = message.Value;
                NameEntry.Text = person.Name;
                AddressEntry.Text = person.Address;
                PhoneEntry.Text = person.Phone;
                EmailEntry.Text = person.Email;
            });
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var person = new Person(NameEntry.Text, AddressEntry.Text, PhoneEntry.Text, EmailEntry.Text);
            WeakReferenceMessenger.Default.Send(new SavePersonMessage(person));
        }

        private void OnLoadButtonClicked(object sender, EventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new LoadPersonMessage());
        }
    }
}