using Syncfusion.Maui.DataForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMAUI
{
    /// <summary>
    /// Represents a behavior class for contact form.
    /// </summary>
    public class ContactFormBehavior : Behavior<ContentPage>
    {
        /// <summary>
        /// Holds the data form object.
        /// </summary>
        private SfDataForm? dataForm;

        ContactsInfoViewModel viewModel;

        /// <inheritdoc/>
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            
            bindable.Loaded += OnEditPageLoaded;
            this.dataForm = bindable.FindByName<SfDataForm>("contactForm");

            if (this.dataForm != null)
            {
                dataForm.ValidateForm += this.OnDataFormValidateForm;
                dataForm.ValidateProperty += this.OnDataFormValidateProperty;
            }
        }

        private void OnEditPageLoaded(object? sender, EventArgs e)
        {
            viewModel = (sender as ContentPage).BindingContext as ContactsInfoViewModel;
        }

        /// <summary>
        /// Invokes on data form item validation.
        /// </summary>
        /// <param name="sender">The data form.</param>
        /// <param name="e">The event arguments.</param>
        private void OnDataFormValidateProperty(object? sender, DataFormValidatePropertyEventArgs e)
        {
            if (e.PropertyName == nameof(ContactInfo.PhoneNumber) && !e.IsValid)
            {
                e.ErrorMessage = e.NewValue == null || string.IsNullOrEmpty(e.NewValue.ToString()) ? "Please enter the mobile number" : "Invalid mobile number";
            }
        }

        /// <summary>
        /// Invokes on manual data form validation.
        /// </summary>
        /// <param name="sender">The data form.</param>
        /// <param name="e">The event arguments.</param>
        private async void OnDataFormValidateForm(object? sender, DataFormValidateFormEventArgs e)
        {
            if (this.dataForm != null && App.Current != null)
            {
                if (e.ErrorMessage != null && e.ErrorMessage.Count > 0)
                {
                    if (e.ErrorMessage.Count == 2)
                    {
                        await App.Current!.Windows[0].Page!.DisplayAlert("", "Please enter the contact name and mobile number", "OK");
                    }
                    else
                    {
                        if (e.ErrorMessage.ContainsKey(nameof(ContactInfo.ContactName)))
                        {
                            await App.Current!.Windows[0].Page!.DisplayAlert("", "Please enter the contact name", "OK");
                        }
                        else
                        {
                            await App.Current!.Windows[0].Page!.DisplayAlert("", "Please enter the mobile number", "OK");
                        }
                    }
                    viewModel.IsValid = false;
                }
                else
                {
                    viewModel.IsValid = true;
                }
            }
        }

        /// <inheritdoc/>
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.dataForm != null)
            {
                this.dataForm.ValidateForm -= this.OnDataFormValidateForm;
                this.dataForm.ValidateProperty -= this.OnDataFormValidateProperty;
                this.dataForm = null;
            }
            bindable.Loaded -= OnEditPageLoaded;
        }
    }
}
