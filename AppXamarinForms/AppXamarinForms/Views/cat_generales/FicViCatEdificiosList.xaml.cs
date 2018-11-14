using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppXamarinForms.Data;
using AppXamarinForms.Interface.SQLite;
using AppXamarinForms.ViewModels.CatGenerales;

namespace AppXamarinForms.Views.cat_generales
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCatEdificiosList : ContentPage
	{
        
		public FicViCatEdificiosList ()
		{
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmCatEdificiosList;                   
        }

        public FicViCatEdificiosList(object FicNavegatioContext) {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmCatEdificiosList;
        }

        protected async override void OnAppearing()

        {
            var FicViewModel = BindingContext as FicVmCatEdificiosList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }
        }
	}
}