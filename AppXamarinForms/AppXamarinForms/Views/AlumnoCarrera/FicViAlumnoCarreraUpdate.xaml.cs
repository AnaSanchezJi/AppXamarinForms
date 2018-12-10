using AppXamarinForms.ViewModels.AlumnoCarrera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarinForms.Views.AlumnoCarrera
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViAlumnoCarreraUpdate : ContentPage
	{
        private object FicCuerpoNavigationContext { get; set; }

		public FicViAlumnoCarreraUpdate(object FicNavigationContext)
		{
			InitializeComponent ();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmAlumnoCarreraUpdate;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAlumnoCarreraUpdate;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;

                FicViewModel.OnAppearing();

            }
        }//SE EJECUTA CUANDO SE ABRE LA VIEW
    }
}