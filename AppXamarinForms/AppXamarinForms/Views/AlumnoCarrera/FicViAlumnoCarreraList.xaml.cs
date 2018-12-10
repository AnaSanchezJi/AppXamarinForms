using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppXamarinForms.Data;
using AppXamarinForms.Interface.SQLite;
using AppXamarinForms.ViewModels.AlumnoCarrera;

namespace AppXamarinForms.Views.AlumnoCarrera
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViAlumnoCarreraList : ContentPage
	{
        
		public FicViAlumnoCarreraList()
		{
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmAlumnoCarreraList;                   
        }

        public FicViAlumnoCarreraList(object FicNavegatioContext) {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmAlumnoCarreraList;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAlumnoCarreraList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }
        }
	}
}