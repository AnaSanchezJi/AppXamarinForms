using AppXamarinForms.ViewModels.CatGenerales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarinForms.Views.cat_generales
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViImportarWebApi : ContentPage
	{
		public FicViImportarWebApi ()
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.FicVmImportarWebApi;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmImportarWebApi;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }

        }
    }
}