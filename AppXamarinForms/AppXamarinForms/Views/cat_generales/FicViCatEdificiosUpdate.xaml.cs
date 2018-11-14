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
	public partial class FicViCatEdificiosUpdate : ContentPage
	{
        private object FicCuerpoNavigationContext { get; set; }

		public FicViCatEdificiosUpdate (object FicNavigationContext)
		{
			InitializeComponent ();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmCatEdificiosUpdate;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCatEdificiosUpdate;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;

                FicViewModel.OnAppearing();

            }
        }//SE EJECUTA CUANDO SE ABRE LA VIEW
    }
}