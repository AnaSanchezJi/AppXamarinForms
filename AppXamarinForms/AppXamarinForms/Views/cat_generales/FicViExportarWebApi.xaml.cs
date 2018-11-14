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
	public partial class FicViExportarWebApi : ContentPage
	{
		public FicViExportarWebApi ()
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.FicVmExportarWebApi;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmExportarWebApi;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }

        }
    }
}