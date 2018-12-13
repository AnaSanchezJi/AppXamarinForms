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
using System.Collections.ObjectModel;
using AppXamarinForms.Models;
using AppXamarinForms.Interface.AlumnoCarrera;
using AppXamarinForms.Services.AlumnoCarrera;

namespace AppXamarinForms.Views.AlumnoCarrera
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViAlumnoCarreraList : ContentPage
	{
        FicSrvAlumnoCarreraList FicService { get; }
        public FicViAlumnoCarreraList()
		{
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmAlumnoCarreraList;
            FicService = new FicSrvAlumnoCarreraList();
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

        public async void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            string FicFiltro = FicSearchBar.Text;
            if (FicFiltro.Equals(""))
            {
                var grid = await FicService.FicMetGetListAlumnos();
                dataGrid.ItemsSource = FicAgregarDatos(grid);
            }
            else
            {
                var grid = await FicService.FicMetGetListAlcaBar(FicFiltro);
                dataGrid.ItemsSource = FicAgregarDatos(grid);
            }
        }

        private ObservableCollection<eva_alumnos_carreras> FicAgregarDatos(IEnumerable<eva_alumnos_carreras> FicPaListRubrica)
        {
            ObservableCollection<eva_alumnos_carreras> source = new ObservableCollection<eva_alumnos_carreras>();
            foreach (var item in FicPaListRubrica)
            {
                source.Add(item);
            }
            return source;
        }
    }
}