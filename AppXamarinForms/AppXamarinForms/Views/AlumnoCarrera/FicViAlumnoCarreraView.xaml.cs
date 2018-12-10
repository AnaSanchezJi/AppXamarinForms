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
	public partial class FicViAlumnoCarreraView : ContentPage
	{
        private object FicCuerpoNavigationContext { get; set; }

        public FicViAlumnoCarreraView(object FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmAlumnoCarreraView;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAlumnoCarreraView;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;

                FicViewModel.OnAppearing();

            }
        }
    }
}