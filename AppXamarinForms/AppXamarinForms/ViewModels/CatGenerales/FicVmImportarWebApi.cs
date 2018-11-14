using AppXamarinForms.Interface.CatGenerales;
using AppXamarinForms.Interface.Navegacion;
using AppXamarinForms.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarinForms.ViewModels.CatGenerales
{
    public class FicVmImportarWebApi : INotifyPropertyChanged
    {
        private string _FicTextAreaImpEdi;
        private ICommand _FicMecImportEdi;

        private IFicSrvNavegationCatEdificiosList IFicSrvNavigationEdificio;
        private IFicSrvImportarWebApi IFicSrvImportarWebApi;
        public FicVmImportarWebApi(IFicSrvNavegationCatEdificiosList IFicSrvNavigationEdificio, IFicSrvImportarWebApi IFicSrvImportarWebApi)
        {
            this.IFicSrvNavigationEdificio = IFicSrvNavigationEdificio;
            this.IFicSrvImportarWebApi = IFicSrvImportarWebApi;
        }//CONSTRUCTOR

        public string FicTextAreaImpEdi
        {
            get { return _FicTextAreaImpEdi; }
        }

        public async void OnAppearing()
        {

        }//METODO QUE SE MANDA A LLAMAR EN LA VIEW
              

        public ICommand FicMecImportEdi
        {
            get
            {
                return _FicMecImportEdi = _FicMecImportEdi ?? new FicVmDelegateCommand(FicMecImportEdificio);
            }
        }//ESTE VENTO AGREGA EL COMANDO AL BOTON EN LA VIEW

        private async void FicMecImportEdificio()
        {
            try
            {
                _FicTextAreaImpEdi = await IFicSrvImportarWebApi.FicGetImportEdificios();
                RaisePropertyChanged("FicTextAreaExpEdi");
                if (_FicTextAreaImpEdi == "OK")
                {
                    await new Page().DisplayAlert("Importar", "Importacion exitosa!", "OK");
                }
                else
                {
                    await new Page().DisplayAlert("Error!", _FicTextAreaImpEdi.ToString(), "OK");
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA ..", e.Message.ToString(), "OK");
            }
        }

       
        #region  INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }//CLASS  
}
