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
	public partial class FicViCatEdificiosView : ContentPage
	{
        private object FicCuerpoNavigationContext { get; set; }

        public FicViCatEdificiosView(object FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmCatEdificiosView;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCatEdificiosView;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;

                FicViewModel.OnAppearing();

            }
        }
    }
}