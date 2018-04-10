using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms_Samples.Models;

namespace XamarinForms_Samples
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetails : ContentPage
	{
		public ContactDetails(Contact contact)
		{
			InitializeComponent ();

            BindingContext = contact;
		}
	}
}