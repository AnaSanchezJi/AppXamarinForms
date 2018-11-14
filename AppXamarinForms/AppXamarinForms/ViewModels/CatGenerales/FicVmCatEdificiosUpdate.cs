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
using AppXamarinForms.Models;

namespace AppXamarinForms.ViewModels.CatGenerales
{
    public class FicVmCatEdificiosUpdate : INotifyPropertyChanged
    {
        private IFicSrvNavegationCatEdificiosList IFicSrvNavigationEdificios;
        private IFicSrvCatEdificiosUpdate IFicSrvCatEdificiosUpdate;

        private string _LabelAlias, _LabelDes, _LabelClave, _LabelAct, _LabelBor, _LabelUsuReg, _LabelUsuMod;
        private short _LabelId, _LabelPrioridad;
        private DateTime _LabelFechaReg, _LabelFechaMod;

        private ICommand _FicMetRegesarCatEdificiosListICommand, _SaveCommand;

        public object FicNavigationContextC { get; set; }

        public FicVmCatEdificiosUpdate(IFicSrvNavegationCatEdificiosList IFicSrvNavigationEdificios, IFicSrvCatEdificiosUpdate IFicSrvCatEdificiosUpdate)
        {
            this.IFicSrvNavigationEdificios = IFicSrvNavigationEdificios;
            this.IFicSrvCatEdificiosUpdate = IFicSrvCatEdificiosUpdate;
        }

        public string LabelAlias
        {
            get { return _LabelAlias; }
            set
            {
                if (value != null)
                {
                    _LabelAlias = value;
                    RaisePropertyChanged("LabelAlias");
                }
            }

        }
        public string LabelDes
        {
            get { return _LabelDes; }
            set
            {
                if (value != null)
                {
                    _LabelDes = value;
                    RaisePropertyChanged("LabelDes");
                }
            }
        }
        public string LabelClave
        {
            get { return _LabelClave; }
            set
            {
                if (value != null)
                {
                    _LabelClave = value;
                    RaisePropertyChanged("LabelClave");
                }
            }
        }

        public short LabelId
        {
            get { return _LabelId; }
            set
            {
                if (value != null)
                {
                    _LabelId = value;
                    RaisePropertyChanged("LabelId");
                }
            }
        }

        public short LabelPrioridad
        {
            get { return _LabelPrioridad; }
            set
            {
                if (value != null)
                {
                    _LabelPrioridad = value;
                    RaisePropertyChanged("LabelPrioridad");
                }
            }
        }

        public DateTime LabelFechaReg
        {
            get { return _LabelFechaReg; }
            set
            {
                if (value != null)
                {
                    _LabelFechaReg = value;
                    RaisePropertyChanged("LabelFechaReg");
                }
            }
        }

        public DateTime LabelFechaMod
        {
            get { return _LabelFechaMod; }
            set
            {
                if (value != null)
                {
                    _LabelFechaMod = value;
                    RaisePropertyChanged("LabelFechaMod");
                }
            }
        }
        public string LabelUsuReg
        {
            get { return _LabelUsuReg; }
            set
            {
                if (value != null)
                {
                    _LabelUsuReg = value;
                    RaisePropertyChanged("LabelUsuReg");
                }
            }
        }

        public string LabelUsuMod
        {
            get { return _LabelUsuMod; }
            set
            {
                if (value != null)
                {
                    _LabelUsuMod = value;
                    RaisePropertyChanged("LabelUsuMod");
                }
            }
        }
        public string LabelAct
        {
            get { return _LabelAct; }
            set
            {
                if (value != null)
                {
                    _LabelAct = value;
                    RaisePropertyChanged("LabelAct");
                }
            }
        }
        public string LabelBor
        {
            get { return _LabelBor; }
            set
            {
                if (value != null)
                {
                    _LabelBor = value;
                    RaisePropertyChanged("LabelBor");
                }
            }
        }
        public async void OnAppearing()
        {
            var source_eva_cat_edificios = FicNavigationContextC as eva_cat_edificios;

            _LabelId = source_eva_cat_edificios.IdEdificio;
            _LabelAlias = source_eva_cat_edificios.Alias;
            _LabelDes = source_eva_cat_edificios.DesEdificio;
            _LabelPrioridad = source_eva_cat_edificios.Prioridad;
            _LabelClave = source_eva_cat_edificios.Clave;
            _LabelFechaReg = source_eva_cat_edificios.FechaReg;
            _LabelFechaMod = source_eva_cat_edificios.FechaUltMod;
            _LabelUsuReg = source_eva_cat_edificios.UsuarioReg;
            _LabelUsuMod = source_eva_cat_edificios.UsuarioMod;
            _LabelAct = source_eva_cat_edificios.Activo;
            _LabelBor = source_eva_cat_edificios.Borrado;

            RaisePropertyChanged("LabelId");
            RaisePropertyChanged("LabelAlias");
            RaisePropertyChanged("LabelDes");
            RaisePropertyChanged("LabelPrioridad");
            RaisePropertyChanged("LabelClave");
            RaisePropertyChanged("LabelFechaReg");
            RaisePropertyChanged("LabelFechaMod");
            RaisePropertyChanged("LabelUsuReg");
            RaisePropertyChanged("LabelUsuMod");
            RaisePropertyChanged("LabelAct");
            RaisePropertyChanged("LabelBor");


        }

        #region MANEJO DE COMANDOS        
        public ICommand FicMetRegesarCatEdificiosListICommand
        {
            get
            {
                return _FicMetRegesarCatEdificiosListICommand = _FicMetRegesarCatEdificiosListICommand ??
                    new FicVmDelegateCommand(FicMetRegresarCatEdificios);
            }
        }

        private async void FicMetRegresarCatEdificios()
        {
            try
            {
                IFicSrvNavigationEdificios.FicMetNavigateTo<FicVmCatEdificiosList>(FicNavigationContextC);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        private async void SaveCommandExecute()
        {
            var source_eva_cat_edificios = FicNavigationContextC as eva_cat_edificios;
            try
            {
                var RespuestaInsert = await IFicSrvCatEdificiosUpdate.Update_eva_cat_edificios(new eva_cat_edificios()
                {
                    IdEdificio = source_eva_cat_edificios.IdEdificio,
                    Alias = LabelAlias,
                    DesEdificio = LabelDes,
                    Prioridad = LabelPrioridad,
                    Clave = LabelClave,
                    FechaReg = source_eva_cat_edificios.FechaReg,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = source_eva_cat_edificios.UsuarioReg,
                    UsuarioMod = "Ana",
                    Activo = LabelAct,
                    Borrado = LabelBor
                });

                if (RespuestaInsert == "OK")
                {
                    await new Page().DisplayAlert("ADD", "¡EDITADO CON EXITO!", "OK");
                    IFicSrvNavigationEdificios.FicMetNavigateTo<FicVmCatEdificiosList>(FicNavigationContextC);
                }
                else
                {
                    await new Page().DisplayAlert("ADD", RespuestaInsert.ToString(), "OK");
                }//SE INSERTO EL CONTEO?
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }//MANEJO GLOBAL DE ERRORES
        }

        #endregion

        #region  INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
