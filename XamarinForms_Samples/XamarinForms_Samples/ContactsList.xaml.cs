using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms_Samples.Models;

namespace XamarinForms_Samples
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactsList : ContentPage
	{
        private ObservableCollection<Contact> _contactsList = null;
		public ContactsList ()
		{
			InitializeComponent ();
            _contactsList = GetContacts();
            SetContactsItemSource();
        }

        private ObservableCollection<Contact> GetContacts(string searchText = null)
        {
            var contacts = new ObservableCollection<Contact>()
            {
                new Contact(){ Name = "Dilip", Status = "Hi, I'm online" },
                new Contact(){ Name = "Bob", Status = "Away" }// ContactURL = "@http://lorempixel.com/100/100/people/1/" },
            };


            if (string.IsNullOrEmpty(searchText))
                return contacts;

            var filteredContacts = contacts.Where(x => x.Name.ToLower().StartsWith(searchText.ToLower())).ToList();
            return new ObservableCollection<Contact>(filteredContacts);
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            DisplayAlert("Call", contact.Name, "Cancel");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            _contactsList.Remove(contact);
        }

        private void SetContactsItemSource()
        {
            Contacts.ItemsSource = _contactsList;
        }

        private void Contacts_Refreshing(object sender, EventArgs e)
        {
            SetContactsItemSource();
            Contacts.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Contacts.ItemsSource = GetContacts(e.NewTextValue);
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            //var value = (sender as SearchBar);
            //Contacts.ItemsSource = GetContacts(value.Text);
        }

        private async void Contacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var contact = e.SelectedItem as Contact;
            await Navigation.PushAsync(new ContactDetails(contact));
            Contacts.SelectedItem = null;
        }
    }
}