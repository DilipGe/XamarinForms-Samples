using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using XamarinForms_Samples.Persistance;

namespace XamarinForms_Samples
{
	public partial class MainPage : ContentPage
	{
        private SQLiteAsyncConnection _connection;
        public class Recipe
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            [MaxLength(255)]
            public string Name { get; set; }
        }
        public MainPage()
		{
			InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            
		}

        protected override void OnAppearing()
        {
            _connection.CreateTableAsync<Recipe>();

            var recipies = _connection.Table<Recipe>().ToListAsync();
           
            
            base.OnAppearing();
        }

        void OnAdd(object sender, System.EventArgs e)
        {
        }

        void OnUpdate(object sender, System.EventArgs e)
        {
        }

        void OnDelete(object sender, System.EventArgs e)
        {
        }
    }
}
