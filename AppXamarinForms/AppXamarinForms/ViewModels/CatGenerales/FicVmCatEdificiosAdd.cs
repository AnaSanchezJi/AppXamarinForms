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
    public class FicVmCatEdificiosAdd : INotifyPropertyChanged
    {
        private IFicSrvNavegationCatEdificiosList IFicSrvNavigationEdificiosList;
        private IFicSrvCatEdificiosAdd IFicSrvCatEdificiosAdd;

        private string _LabelAlias, _LabelDes, _LabelClave, _LabelUsuReg, _LabelUsuMod, _LabelAct, _LabelBor;
        private short _LabelPrioridad, _LabelId;
        private DateTime _LabelFechaReg, _LabelFechaMod;


        private ICommand _FicMetRegesarCatEdificiosListICommand, _SaveCommand;

        public object[] FicNavigationContextC { get; set; }

        public FicVmCatEdificiosAdd(IFicSrvNavegationCatEdificiosList ficSrvNavigationEdificiosList, IFicSrvCatEdificiosAdd ficSrvCatEdificiosAdd)
        {
            this.IFicSrvNavigationEdificiosList = ficSrvNavigationEdificiosList;
            this.IFicSrvCatEdificiosAdd = ficSrvCatEdificiosAdd;
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

        }

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
                IFicSrvNavigationEdificiosList.FicMetNavigateTo<FicVmCatEdificiosList>(FicNavigationContextC);
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
            try
            {
                var RespuestaInsert = await IFicSrvCatEdificiosAdd.Insert_eva_cat_edificios(new eva_cat_edificios()
                {
                    IdEdificio = LabelId,
                    Alias = LabelAlias,
                    DesEdificio = LabelDes,
                    Prioridad = LabelPrioridad,
                    Clave = LabelClave,
                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = LabelUsuReg,
                    UsuarioMod = LabelUsuMod,
                    Activo = LabelAct,
                    Borrado = LabelBor
                });

                if (RespuestaInsert == "OK")
                {
                    await new Page().DisplayAlert("ADD", "¡INSERTADO CON EXITO!", "OK");
                    IFicSrvNavigationEdificiosList.FicMetNavigateTo<FicVmCatEdificiosList>(FicNavigationContextC);
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





        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

