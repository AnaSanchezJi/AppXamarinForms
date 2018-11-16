using AppXamarinForms.Interface.CatGenerales;
using AppXamarinForms.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarinForms.ViewModels.CatGenerales
{
    public class FicVmImpExpWebApi
    {
        #region VARIABLES
        //Interfaces
        private IFicSrvImpExpWebApi IFicImportarExportar;

        //Comandos
        private ICommand _ImportarCommand, _ExportarCommand;

        #endregion

        public FicVmImpExpWebApi(IFicSrvImpExpWebApi IFicImportarExportar)
        {
            this.IFicImportarExportar = IFicImportarExportar;
        }

        public async void OnAppearing()
        {

        }
        #region Commandos

        public ICommand ImportCommand
        {
            get { return _ImportarCommand = _ImportarCommand ?? new FicVmDelegateCommand(ImportarCommandExecute); }
        }

        private async void ImportarCommandExecute()
        {
            try
            {
                var res = await IFicImportarExportar.FicImportEdificios();

                if (res == "OK")
                {
                    await new Page().DisplayAlert("Importar", "Importacion exitosa!", "OK");
                }
                else
                {
                    await new Page().DisplayAlert("Error al importar", res.ToString(), "OK");
                }

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Exception", e.Message.ToString(), "OK");
            }
        }

        public ICommand ExportCommand
        {
            get { return _ExportarCommand = _ExportarCommand ?? new FicVmDelegateCommand(ExportarCommandExecute); }
        }

        private async void ExportarCommandExecute()
        {
            try
            {
                var res = await IFicImportarExportar.FicExportEdificios();

                if (res == "OK")
                {
                    await new Page().DisplayAlert("Exportar", "Exportacion exitosa!", "OK");
                }
                else
                {
                    await new Page().DisplayAlert("Error al exportar", res.ToString(), "OK");
                }

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Exception", e.Message.ToString(), "OK");
            }
        }

        #endregion
    }
}
