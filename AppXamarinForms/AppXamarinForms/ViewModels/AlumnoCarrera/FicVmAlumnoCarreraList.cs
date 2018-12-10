﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using AppXamarinForms.Interface.AlumnoCarrera;
using AppXamarinForms.Interface.Navegacion;
using AppXamarinForms.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AppXamarinForms.Services.AlumnoCarrera;
using Xamarin.Forms;
using AppXamarinForms.Models;

namespace AppXamarinForms.ViewModels.AlumnoCarrera
{
    public class FicVmAlumnoCarreraList : INotifyPropertyChanged
    {
        public ObservableCollection<eva_alumnos_carreras> _FicSfDataGrid_ItemSource_Alumnos;
        public eva_alumnos_carreras _FicSfDataGrid_SelectItem_Alumnos;
        private ICommand _FicMetAddAlumnoICommand;
        private ICommand _FicMetUpdateAlumnoICommand;
        private ICommand _FicMetRemoveAlumnoICommand;
        private ICommand _FicMetViewAlumnoICommand;
        


        private IFicSrvNavegationCatEdificiosList IFicSrvNavigationCatEdificios;
        private IFicSvrAlumnoCarreraList IFicSrcAlumnoCarreraList;
        private IFicSrvAlumnoCarreraAdd IFicSrcAlumnoCarreraAdd;
        private IFicSrvAlumnoCarreraUpdate IFicSrvAlumnoCarreraUpdate;

       
        public FicVmAlumnoCarreraList(IFicSvrAlumnoCarreraList IFicSrcAlumnoCarreraList, 
            IFicSrvNavegationCatEdificiosList IFicSrvNavigationCatEdificios,
            IFicSrvAlumnoCarreraAdd IFicSrvAlumnoCarreraAdd,
            IFicSrvAlumnoCarreraUpdate IFicSrvAlumnoCarreraUpdate)
        {
            this.IFicSrvNavigationCatEdificios = IFicSrvNavigationCatEdificios;
            this.IFicSrcAlumnoCarreraList = IFicSrcAlumnoCarreraList;
            this.IFicSrcAlumnoCarreraAdd = IFicSrvAlumnoCarreraAdd;
            this.IFicSrvAlumnoCarreraUpdate = IFicSrvAlumnoCarreraUpdate;
           

            _FicSfDataGrid_ItemSource_Alumnos = new ObservableCollection<eva_alumnos_carreras>();
        }

        public ObservableCollection<eva_alumnos_carreras> FicSfDataGrid_ItemSource_Alumnos
        {
            get
            {
                return _FicSfDataGrid_ItemSource_Alumnos;
            }
        }//Apunta al BindigContext al grid del view

        public eva_alumnos_carreras FicSfDataGrid_SelectItem_Alumnos
        {
            get
            {
                return _FicSfDataGrid_SelectItem_Alumnos;
            }
            set
            {
                if (value != null)
                {
                    _FicSfDataGrid_SelectItem_Alumnos = value;
                    RaisePropertyChanged();
                }
            }
        }////Apunta al grid seleccionado de la view

        public ICommand FicMetAddAlumnoICommand
        {
            get
            {
                return _FicMetAddAlumnoICommand = _FicMetAddAlumnoICommand ?? new FicVmDelegateCommand(FicMetAlumnoAdd);
            }
        }//agrega el comando al boton del view

        private void FicMetAlumnoAdd()
        {
            IFicSrvNavigationCatEdificios.FicMetNavigateTo<FicVmAlumnoCarreraAdd>();
        }
       
        public ICommand FicMetUpdateAlumnoICommand
        {
            get
            {
                return _FicMetUpdateAlumnoICommand = _FicMetUpdateAlumnoICommand ?? new FicVmDelegateCommand(FicMetUpdateAlumno);
            }
        }

        private void FicMetUpdateAlumno()
        {
            if (FicSfDataGrid_SelectItem_Alumnos != null)
            {
                IFicSrvNavigationCatEdificios.FicMetNavigateTo<FicVmAlumnoCarreraUpdate>(FicSfDataGrid_SelectItem_Alumnos);
            }
        }

        public ICommand FicMetViewAlumnoICommand
        {
            get
            {
                return _FicMetViewAlumnoICommand = _FicMetViewAlumnoICommand ?? new FicVmDelegateCommand(FicMetViewAlumno);
            }
        }

        private void FicMetViewAlumno()
        {
            if (FicSfDataGrid_SelectItem_Alumnos != null)
            {
                IFicSrvNavigationCatEdificios.FicMetNavigateTo<FicVmAlumnoCarreraView>(FicSfDataGrid_SelectItem_Alumnos);
            }
        }

        public ICommand FicMetRemoveAlumnoICommand
        {
            get
            {
                return _FicMetRemoveAlumnoICommand = _FicMetRemoveAlumnoICommand ?? new FicVmDelegateCommand(FicMetRemoveAlumno);
            }
        }

        
        private async void FicMetRemoveAlumno()
        {
            if (FicSfDataGrid_SelectItem_Alumnos != null)
            {

                var ask = await new Page().DisplayAlert("Eliminar", "¿Seguro que desea eliminar?", "Si", "No");
                if (ask)
                {
                    var res = await IFicSrcAlumnoCarreraList.RemoveAlumnos(FicSfDataGrid_SelectItem_Alumnos);
                    if (res == "OK")
                    {                       
                        IFicSrvNavigationCatEdificios.FicMetNavigateTo<FicVmAlumnoCarreraList>();
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
                var source_local_ed = await IFicSrcAlumnoCarreraList.FicMetGetListAlumnos();
                if (source_local_ed != null)
                {
                    foreach (eva_alumnos_carreras ed in source_local_ed)
                    {
                        _FicSfDataGrid_ItemSource_Alumnos.Add(ed);
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