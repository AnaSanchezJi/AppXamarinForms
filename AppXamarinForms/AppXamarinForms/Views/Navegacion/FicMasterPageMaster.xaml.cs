using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AppXamarinForms.Views.AlumnoCarrera;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarinForms.Views.Navegacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicMasterPageMaster : ContentPage
    {
        public ListView ListView;

        public FicMasterPageMaster()
        {
            InitializeComponent();

            BindingContext = new FicMasterPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class FicMasterPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FicMasterPageMenuItem> MenuItems { get; set; }
            
            public FicMasterPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<FicMasterPageMenuItem>(new[]
                {
                    new FicMasterPageMenuItem { Id = 0, Title = "Importacion Web Api",
                                                 //Icon ="ficAlmacen20x20.png",
                                                  FicPageName ="FicViImportarWebApi",
                                                  TargetType = typeof(ViCatEdificiosImportarExportar )
                                                  },
                    /*new FicMasterPageMenuItem { Id = 0, Title = "Exportar Web Api",
                                                //Icon ="ficAlmacen20x20.png",
                                                FicPageName ="FicViExportarWebApi",
                                                TargetType = typeof(FicViExportarWebApi)
                                                },*/
                    new FicMasterPageMenuItem { Id = 0, Title = "Alumos Carreras",
                                                //Icon ="ficAlmacen20x20.png",
                                                FicPageName ="FicViCatEdificiosList",
                                                TargetType = typeof(FicViAlumnoCarreraList)
                                                }
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}