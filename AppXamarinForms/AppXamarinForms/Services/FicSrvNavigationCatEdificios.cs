using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AppXamarinForms.Interface.Navegacion;
using AppXamarinForms.ViewModels.AlumnoCarrera;
using AppXamarinForms.Views.AlumnoCarrera;

namespace AppXamarinForms.Services
{
    public class FicSrvNavigationCatEdificios : IFicSrvNavegationCatEdificiosList
    {
        private IDictionary<Type, Type> FicViewModelRouting = new Dictionary<Type, Type>()
        {
            //AQUI SE HACE UNA UNION ENTRE LA VM Y VI DE CADA VIEW DE LA APP
            { typeof(FicVmAlumnoCarreraList),typeof(FicViAlumnoCarreraList) },
            { typeof(FicVmAlumnoCarreraAdd),typeof(FicViAlumnoCarreraAdd) },
            { typeof(FicVmAlumnoCarreraUpdate),typeof(FicViAlumnoCarreraUpdate) },
            { typeof(FicVmAlumnoCarreraView),typeof(FicViAlumnoCarreraView) },
           // {typeof(FicVmImportarWebApi), typeof(FicViImportarWebApi)},
            //{typeof(FicVmExportarWebApi), typeof(FicViExportarWebApi)}

        };

        public void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[typeof(FicTDestinationViewModel)];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }

        public void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[FicDestinationType];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }

        public void FicMetNavigateBack()
        {
            Application.Current.MainPage.Navigation.PopAsync(true);
        }
    }
}
