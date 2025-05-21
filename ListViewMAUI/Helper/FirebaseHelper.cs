using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMAUI
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("your database URL");

        public async Task AddContact(ContactInfo contact)
        {
            var isNewContact = !(await firebase
                    .Child("Contacts")
                    .OnceAsync<ContactInfo>())
                    .Any(c => c.Object.Id == contact.Id);
            
            var contactToSave = new ContactInfo() { Id = contact.Id,ContactName=contact.ContactName,ContactNumber=contact.ContactNumber };
            
            if (isNewContact)
            {
                await firebase
                  .Child("Contacts")
                  .PostAsync(contactToSave);
            }
            else
            {
                await UpdateContact(contactToSave);
            }
        }

        public async Task UpdateContact(ContactInfo contact)
        {
            var toUpdateContact = (await firebase
              .Child("Contacts")
              .OnceAsync<ContactInfo>()).Where(a => a.Object.Id == contact.Id).FirstOrDefault();
            
            if (toUpdateContact != null)
            {
                await firebase
                  .Child("Contacts")
                  .Child(toUpdateContact!.Key)
                  .PutAsync(contact);
            }
        }

        public async Task DeleteContact(ContactInfo contact)
        {
            var toDeleteContact= (await firebase
              .Child("Contacts")
              .OnceAsync<ContactInfo>()).Where(a => a.Object.Id == contact.Id).FirstOrDefault();
            
            if (toDeleteContact != null)
            {
                await firebase.Child("Contacts").Child(toDeleteContact!.Key).DeleteAsync();
            }
        }
    }
}
