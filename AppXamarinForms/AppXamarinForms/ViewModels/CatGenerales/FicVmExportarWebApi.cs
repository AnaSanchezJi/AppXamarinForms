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
    public class FicVmExportarWebApi : INotifyPropertyChanged
    {
        private string _FicTextAreaExpEdi;
        private ICommand _FicMetExpoEdi;

        private IFicSrvNavegationCatEdificiosList IFicSrvNavigationEdificios;
        private IFicSrvExportarWebApi IFicSrvExportarWebApi;

        public FicVmExportarWebApi(IFicSrvNavegationCatEdificiosList IFicSrvNavigationEdificios, IFicSrvExportarWebApi IFicSrvExportarWebApi)
        {
            this.IFicSrvNavigationEdificios = IFicSrvNavigationEdificios;
            this.IFicSrvExportarWebApi = IFicSrvExportarWebApi;
        }//CONSTRUCTOR

        public string FicTextAreaExpEdi
        {
            get { return _FicTextAreaExpEdi; }
        }

        public async void OnAppearing()
        {

        }//AL INICIAR DE LA VIEW

        public ICommand FicMetExpoEdi
        {
            get
            {
                return _FicMetExpoEdi = _FicMetExpoEdi ?? new FicVmDelegateCommand(FicMetExportEdificios);
            }
        }//ESTE VENTO AGREGA EL COMANDO AL BOTON EN LA VIEW

        private async void FicMetExportEdificios()
        {
            try
            {
                _FicTextAreaExpEdi = await IFicSrvExportarWebApi.FicPostExportEdificios();
                RaisePropertyChanged("FicTextAreaExpEdi");
                if (_FicTextAreaExpEdi == "OK")
                {
                    await new Page().DisplayAlert("ALERTA", "Datos Actualizados.", "OK");
                }
                else
                {
                    await new Page().DisplayAlert("Error al exportar",_FicTextAreaExpEdi.ToString(), "OK");
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA 2", e.Message.ToString(), "OK");
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
