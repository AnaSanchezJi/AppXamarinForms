using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using AppXamarinForms.Interface.CatGenerales;
using AppXamarinForms.Interface.Navegacion;
using AppXamarinForms.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AppXamarinForms.Services.CatGenerales;
using Xamarin.Forms;
using AppXamarinForms.Models;

namespace AppXamarinForms.ViewModels.CatGenerales
{
    public class FicVmCatEdificiosList : INotifyPropertyChanged
    {
        public ObservableCollection<eva_cat_edificios> _FicSfDataGrid_ItemSource_CatEdificios;
        public eva_cat_edificios _FicSfDataGrid_SelectItem_CatEdificios;
        private ICommand _FicMetAddEdificioICommand;
        private ICommand _FicMetUpdateEdificioICommand;
        private ICommand _FicMetRemoveEdificioICommand;
        private ICommand _FicMetViewEdificioICommand;


        private IFicSrvNavegationCatEdificiosList IFicSrvNavigationCatEdificios;
        private IFicSvrCatEdificiosList IFicSrcCatEdificiosList;
        private IFicSrvCatEdificiosAdd IFicSrcCatEdificiosAdd;
        private IFicSrvCatEdificiosUpdate IFicSrvCatEficiosUpdate;

        public FicVmCatEdificiosList(IFicSvrCatEdificiosList IFicSrcCatEdificiosList, 
            IFicSrvNavegationCatEdificiosList IFicSrvNavigationCatEdificios,
            IFicSrvCatEdificiosAdd IFicSrvCatEdificiosAdd,
            IFicSrvCatEdificiosUpdate IFicSrvCatEdificiosUpdate)
        {
            this.IFicSrvNavigationCatEdificios = IFicSrvNavigationCatEdificios;
            this.IFicSrcCatEdificiosList = IFicSrcCatEdificiosList;
            this.IFicSrcCatEdificiosAdd = IFicSrvCatEdificiosAdd;
            this.IFicSrvCatEficiosUpdate = IFicSrvCatEdificiosUpdate;

            _FicSfDataGrid_ItemSource_CatEdificios = new ObservableCollection<eva_cat_edificios>();
        }

        public ObservableCollection<eva_cat_edificios> FicSfDataGrid_ItemSource_CatEdificios
        {
            get
            {
                return _FicSfDataGrid_ItemSource_CatEdificios;
            }
        }//Apunta al BindigContext al grid del view

        public eva_cat_edificios FicSfDataGrid_SelectItem_CatEdificios
        {
            get
            {
                return _FicSfDataGrid_SelectItem_CatEdificios;
            }
            set
            {
                if (value != null)
                {
                    _FicSfDataGrid_SelectItem_CatEdificios = value;
                    RaisePropertyChanged();
                }
            }
        }////Apunta al grid seleccionado de la view

        public ICommand FicMetAddEdificioICommand
        {
            get
            {
                return _FicMetAddEdificioICommand = _FicMetAddEdificioICommand ?? new FicVmDelegateCommand(FicMetEdificioAdd);
            }
        }//agrega el comando al boton del view

        private void FicMetEdificioAdd()
        {
            IFicSrvNavigationCatEdificios.FicMetNavigateTo<FicVmCatEdificiosAdd>();
        }

        public ICommand FicMetUpdateEdificioICommand
        {
            get
            {
                return _FicMetUpdateEdificioICommand = _FicMetUpdateEdificioICommand ?? new FicVmDelegateCommand(FicMetUpdateEdificio);
            }
        }

        private void FicMetUpdateEdificio()
        {
            if (FicSfDataGrid_SelectItem_CatEdificios != null)
            {
                IFicSrvNavigationCatEdificios.FicMetNavigateTo<FicVmCatEdificiosUpdate>(FicSfDataGrid_SelectItem_CatEdificios);
            }
        }

        public ICommand FicMetViewEdificioICommand
        {
            get
            {
                return _FicMetViewEdificioICommand = _FicMetViewEdificioICommand ?? new FicVmDelegateCommand(FicMetViewEdificio);
            }
        }

        private void FicMetViewEdificio()
        {
            if (FicSfDataGrid_SelectItem_CatEdificios != null)
            {
                IFicSrvNavigationCatEdificios.FicMetNavigateTo<FicVmCatEdificiosView>(FicSfDataGrid_SelectItem_CatEdificios);
            }
        }

        public ICommand FicMetRemoveEdificioICommand
        {
            get
            {
                return _FicMetRemoveEdificioICommand = _FicMetRemoveEdificioICommand ?? new FicVmDelegateCommand(FicMetRemoveEdificio);
            }
        }

        
        private async void FicMetRemoveEdificio()
        {
            if (FicSfDataGrid_SelectItem_CatEdificios != null)
            {

                var ask = await new Page().DisplayAlert("ALERTA!", "Seguro que esea eliminar?", "Si", "No");
                if (ask)
                {
                    var res = await IFicSrcCatEdificiosList.Remove_eva_cat_edificios(FicSfDataGrid_SelectItem_CatEdificios);
                    if (res == "OK")
                    {                       
                        IFicSrvNavigationCatEdificios.FicMetNavigateTo<FicVmCatEdificiosList>();
                    }
                    else
                    {
                        await new Page().DisplayAlert("DELETE", res.ToString(), "OK");
                    }
                }                

            }
        }


        public async void OnAppearing()
        {
            try
            {
                var source_local_ed = await IFicSrcCatEdificiosList.FicMetGetListEdificios();
                if (source_local_ed != null)
                {
                    foreach(eva_cat_edificios ed in source_local_ed)
                    {
                        _FicSfDataGrid_ItemSource_CatEdificios.Add(ed);
                    }//llenar grid
                }

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
   
    }
}
