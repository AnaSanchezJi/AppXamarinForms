using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppXamarinForms.Models;
using AppXamarinForms.ViewModels;
using AppXamarinForms.ViewModels.CatGenerales;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarinForms.Views.cat_generales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCatEdificiosAdd : ContentPage
    {
        private object[] FicCuerpoNavigationContext { get; set; }
        public FicViCatEdificiosAdd(object[] FicNavigationContext)
        {
            InitializeComponent();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmCatEdificiosAdd;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCatEdificiosAdd;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;

                FicViewModel.OnAppearing();
            }
        }
    }
}