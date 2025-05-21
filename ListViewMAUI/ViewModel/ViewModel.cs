using Syncfusion.Maui.DataForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ListViewMAUI
{
    public class ContactsInfoViewModel
    {
        FirebaseHelper firebaseHelper;
        public ContactsInfoViewModel() 
        {
            firebaseHelper = new FirebaseHelper();
            Contacts = new ContactsInfoRepository().GetContactDetails(20);
            PopulateDB();

            CreateNewContactCommand = new Command(ExecuteCreateNewContact);
            EditContactCommand = new Command<object>(ExecuteEditContact);
            DeleteItemCommand = new Command(ExecuteDeleteItem);
            AddItemCommand = new Command<object>(ExecuteAddItem);
            CancelEditCommand = new Command(ExecuteCancelEdit);
        }

        #region Properties
        public ObservableCollection<ContactInfo> Contacts { get; set; }
        public ContactInfo SelectedItem { get; set; }
        public ICommand CreateNewContactCommand { get; set; }
        public ICommand EditContactCommand { get; set; }

        public ICommand DeleteItemCommand { get; set; }
        public ICommand AddItemCommand { get; set; }
        public ICommand CancelEditCommand { get; set; }
        internal bool IsValid { get; set; }

        #endregion

        #region Methods
        private async void PopulateDB()
        {
            foreach (var contact in Contacts)
            {
                await firebaseHelper.AddContact(contact);
            }
        }

        private async void ExecuteCancelEdit()
        {
            await App.Current!.Windows[0].Page!.Navigation.PopAsync();
        }

        private async void ExecuteAddItem(object obj)
        {
            if (obj is SfDataForm dataForm)
            {
                dataForm.Validate();
                if (IsValid)
                {
                    await firebaseHelper.AddContact(SelectedItem);
                    if (!Contacts.Contains(SelectedItem))
                    {
                        Contacts.Add(SelectedItem);
                    }
                    await App.Current!.Windows[0].Page!.Navigation.PopAsync();
                    await App.Current!.Windows[0].Page!.DisplayAlert("", "Contact saved", "OK");
                }
            }
        }

        private async void ExecuteDeleteItem()
        {
            await firebaseHelper.DeleteContact(SelectedItem);
            Contacts.Remove(SelectedItem);
            await App.Current!.Windows[0].Page!.Navigation.PopAsync();
            await App.Current!.Windows[0].Page!.DisplayAlert("", "Contact deleted", "OK");
        }

        // Open edit form when tapping the contact.
        private void ExecuteEditContact(object obj)
        {
            SelectedItem = (obj as Syncfusion.Maui.ListView.ItemTappedEventArgs).DataItem as ContactInfo;
            var editPage = new EditPage() { BindingContext = this };
            App.Current!.Windows[0].Page!.Navigation.PushAsync(editPage);
        }

        // Open edit form when click add button.
        private void ExecuteCreateNewContact()
        {
            SelectedItem = new ContactInfo() { ContactName = "", PhoneNumber = "", ContactImage = "newcontact.png" };
            SelectedItem.Id = this.Contacts.Last().Id + 1;
            var editPage = new EditPage() { BindingContext = this };
            App.Current!.Windows[0].Page!.Navigation.PushAsync(editPage);
        }
        #endregion
    }
}
