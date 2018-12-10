using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppXamarinForms.Models;
using AppXamarinForms.ViewModels;
using AppXamarinForms.ViewModels.AlumnoCarrera;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarinForms.Views.AlumnoCarrera
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViAlumnoCarreraAdd : ContentPage
    {
        private object[] FicCuerpoNavigationContext { get; set; }
        public FicViAlumnoCarreraAdd(object[] FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmAlumnoCarreraAdd;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAlumnoCarreraAdd;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;

                FicViewModel.OnAppearing();
            }
        }
    }
}