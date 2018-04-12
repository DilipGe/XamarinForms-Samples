using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinForms_Samples
{
	public partial class App : Application
	{
        private const string TitleKey = "Name";
        private const string NotificationEnabledKey = "NotificationEnabled";
		public App ()
		{
			InitializeComponent();

            //MainPage = new XamarinForms_Samples.MainPage();
            //MainPage = new NavigationPage(new XamarinForms_Samples.ContactsList());
            //MainPage = new XamarinForms_Samples.TableViewSample();
            //MainPage = new XamarinForms_Samples.DataStorage.ApplicationProperties();
            MainPage = new XamarinForms_Samples.WithSQLite();
        }

        public string Title
        {
            get
            {
                if (Properties.ContainsKey(TitleKey))
                    return Properties[TitleKey].ToString();
                else
                    return string.Empty;
            }
            set
            {
                Properties[TitleKey] = value;
            }
        }

        public string NotificationEnabled
        {
            get
            {
                if (Properties.ContainsKey(NotificationEnabledKey))
                    return Properties[NotificationEnabledKey].ToString();
                else
                    return string.Empty;
            }
            set
            {
                Properties[NotificationEnabledKey] = value;
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}


	}
}
