using AppXamarinForms.Interface.AlumnoCarrera;
using AppXamarinForms.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using AppXamarinForms.Interface.Navegacion;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using AppXamarinForms.ViewModels.Base;
using System.Threading.Tasks;
using AppXamarinForms.Data;


namespace AppXamarinForms.ViewModels.AlumnoCarrera
{
    public class FicVmAlumnoCarreraAdd : INotifyPropertyChanged
    {
        private IFicSrvNavegationCatEdificiosList IFicSrvNavigationEdificiosList;
        private IFicSrvAlumnoCarreraAdd IFicSrvAlumnoCarreraAdd;

        private short _LabelIdCarrera;
        private short _LabelIdAlumno;
        private int _LabelIdReticula;
        private short _LabelIdEspecialidad;
        private DateTime _LabelFechaIngreso;
        private DateTime _LabelFechaEgreso;
        private DateTime _LabelFechaTitulacion;
        private DateTime _LabelFechaUltModSII;
        private float _LabelPromedioActual;
        private int _LabelPromedioPeriodoAnt;
        private float _LabelPromedioFinal;
        private float _LabelCreditosAprobados;
        private float _LabelCreditosCursados;
        private float _LabelTotalPuntosVigentes;
        private float _LabelTotalPuntosGenerados;
        private short _LabelSemestreActual;
        private short _LabelIdPeriodoIngreso;
        private short _LabelIdPeriodoUltimo;
        private short _LabelIdPeriodoTitulacion;

        private short _LabelIdTipoGenPlanEstudio;
        private short _LabelIdGenPlanEstudio;
        private short _LabelIdTipoGenOpcionTitulacion;
        private short _LabelIdGenOpcionTitulacion;
        private short _LabelIdTipoGenNivelEscolar;
        private short _LabelIdGenNivelEscolar;
        private short _LabelIdTipoGenIngreso;
        private short _LabelIdGenIngreso;

        private string _LabelActivo;
        private string _LabelBorrado;
        private DateTime _LabelFechaReg;
        private string _LabelUsuarioReg;
        private DateTime _LabelFechaUltMod;
        private string _LabelUsuarioMod;
        
        private ICommand _FicMetRegesarAlumnosListICommand, _SaveCommand;

        public object[] FicNavigationContextC { get; set; }

        public FicVmAlumnoCarreraAdd(IFicSrvNavegationCatEdificiosList ficSrvNavigationEdificiosList, IFicSrvAlumnoCarreraAdd ficSrvAlumnoCarreraAdd)
        {
            this.IFicSrvNavigationEdificiosList = ficSrvNavigationEdificiosList;
            this.IFicSrvAlumnoCarreraAdd = ficSrvAlumnoCarreraAdd;
        }
        
        public short LabelIdCarrera
        {
            get
            {
                return _LabelIdCarrera;
            }
            set
            {
                if (value != null)
                {
                    _LabelIdCarrera = value;
                    RaisePropertyChanged("LabelIdCarrera");
                }
            }
        }

        
        public short LabelIdAlumno
        {
            get { return _LabelIdAlumno; }
            set
            {
                if (value != null)
                {
                    _LabelIdAlumno = value;
                    RaisePropertyChanged("LabelIdAlumno");
                }
            }
        }


        public int LabelIdReticula
        {
            get { return _LabelIdReticula; }
            set
            {
                if (value != null)
                {
                    _LabelIdReticula = value;
                    RaisePropertyChanged("LabelIdReticula");
                }
            }
        }
        public short LabelIdEspecialidad
        {
            get { return _LabelIdEspecialidad; }
            set
            {
                if (value != null)
                {
                    _LabelIdEspecialidad = value;
                    RaisePropertyChanged("LabelIdEspecialidad");
                }
            }
        }
        public DateTime LabelFechaIngreso
        {
            get { return _LabelFechaIngreso; }
            set
            {
                if (value != null)
                {
                    _LabelFechaIngreso = value;
                    RaisePropertyChanged("LabelFechaIngreso");
                }
            }
        }
        public DateTime LabelFechaEgreso
        {
            get { return _LabelFechaEgreso; }
            set
            {
                if (value != null)
                {
                    _LabelFechaEgreso = value;
                    RaisePropertyChanged("LabelFechaEgreso ");
                }
            }
        }
        public DateTime LabelFechaTitulacion
        {
            get { return _LabelFechaTitulacion; }
            set
            {
                if (value != null)
                {
                    _LabelFechaTitulacion = value;
                    RaisePropertyChanged("LabelFechaTitulacion");
                }
            }
        }
        public DateTime LabelFechaUltModSII
        {
            get { return _LabelFechaUltModSII; }
            set
            {
                if (value != null)
                {
                    _LabelFechaEgreso = value;
                    RaisePropertyChanged("LabelFechaUltModSII");
                }
            }
        }
        public float LabelPromedioActual
        {
            get { return _LabelPromedioActual; }
            set
            {
                if (value != null)
                {
                    _LabelPromedioActual = value;
                    RaisePropertyChanged("LabelPromedioActual");
                }
            }
        }
        public int LabelPromedioPeriodoAnt
        {
            get { return _LabelPromedioPeriodoAnt; }
            set
            {
                if (value != null)
                {
                    _LabelPromedioPeriodoAnt = value;
                    RaisePropertyChanged("LabelPromedioPeriodoAnt");
                }
            }
        }
        public float LabelPromedioFinal
        {
            get { return _LabelPromedioFinal; }
            set
            {
                if (value != null)
                {
                    _LabelPromedioFinal = value;
                    RaisePropertyChanged("LabelPromedioFinal");
                }
            }
        }        
        public float LabelCreditosAprobados
        {
            get { return _LabelCreditosAprobados; }
            set
            {
                if (value != null)
                {
                    _LabelCreditosAprobados = value;
                    RaisePropertyChanged("LabelCreditosAprobados");
                }
            }
        }
        public float LabelCreditosCursados
        {
            get { return _LabelCreditosCursados; }
            set
            {
                if (value != null)
                {
                    _LabelCreditosCursados = value;
                    RaisePropertyChanged("LabelCreditosCursados");
                }
            }
        }
        public float LabelTotalPuntosVigentes
        {
            get { return _LabelTotalPuntosVigentes; }
            set
            {
                if (value != null)
                {
                    _LabelTotalPuntosVigentes = value;
                    RaisePropertyChanged("LabelTotalPuntosVigentes");
                }
            }
        }
        public float LabelTotalPuntosGenerados
        {
            get { return _LabelTotalPuntosGenerados; }
            set
            {
                if (value != null)
                {
                    _LabelTotalPuntosGenerados = value;
                    RaisePropertyChanged("LabelTotalPuntosGenerados");
                }
            }
        }
        public short LabelSemestreActual
        {
            get { return _LabelSemestreActual; }
            set
            {
                if (value != null)
                {
                    _LabelSemestreActual = value;
                    RaisePropertyChanged("LabelSemestreActual");
                }
            }
        }
        public short LabelIdPeriodoIngreso
        {
            get { return _LabelIdPeriodoIngreso; }
            set
            {
                if (value != null)
                {
                    _LabelIdPeriodoIngreso = value;
                    RaisePropertyChanged("LabelIdPeriodoIngreso");
                }
            }
        }
        public short LabelIdPeriodoUltimo
        {
            get { return _LabelIdPeriodoUltimo; }
            set
            {
                if (value != null)
                {
                    _LabelIdPeriodoUltimo = value;
                    RaisePropertyChanged("LabelIdPeriodoUltimo");
                }
            }
        }
        public short LabelIdPeriodoTitulacion
        {
            get { return _LabelIdPeriodoTitulacion; }
            set
            {
                if (value != null)
                {
                    _LabelIdPeriodoTitulacion = value;
                    RaisePropertyChanged("LabelIdPeriodoTitulacion");
                }
            }
        }
        public short LabelIdTipoGenPlanEstudio
        {
            get { return _LabelIdTipoGenPlanEstudio; }
            set
            {
                if (value != null)
                {
                    _LabelIdTipoGenPlanEstudio = value;
                    RaisePropertyChanged("LabelIdTipoGenPlanEstudio");
                }
            }
        }
        public short LabelIdGenPlanEstudio
        {
            get { return _LabelIdGenPlanEstudio; }
            set
            {
                if (value != null)
                {
                    _LabelIdGenPlanEstudio = value;
                    RaisePropertyChanged("LabelIdGenPlanEstudio");
                }
            }
        }
        public short LabelIdTipoGenOpcionTitulacion
        {
            get { return _LabelIdTipoGenOpcionTitulacion; }
            set
            {
                if (value != null)
                {
                    _LabelIdTipoGenOpcionTitulacion = value;
                    RaisePropertyChanged("LabelIdTipoGenOpcionTitulacion");
                }
            }
        }
        public short LabelIdGenOpcionTitulacion
        {
            get { return _LabelIdGenOpcionTitulacion; }
            set
            {
                if (value != null)
                {
                    _LabelIdGenOpcionTitulacion = value;
                    RaisePropertyChanged("LabelIdGenOpcionTitulacion");
                }
            }
        }
        public short LabelIdTipoGenNivelEscolar
        {
            get { return _LabelIdTipoGenNivelEscolar; }
            set
            {
                if (value != null)
                {
                    _LabelIdTipoGenNivelEscolar = value;
                    RaisePropertyChanged("LabelIdTipoGenNivelEscolar");
                }
            }
        }
        public short LabelIdGenNivelEscolar
        {
            get { return _LabelIdGenNivelEscolar; }
            set
            {
                if (value != null)
                {
                    _LabelIdGenNivelEscolar = value;
                    RaisePropertyChanged("LabelIdGenNivelEscolar");
                }
            }
        }
        public short LabelIdTipoGenIngreso
        {
            get { return _LabelIdTipoGenIngreso; }
            set
            {
                if (value != null)
                {
                    _LabelIdTipoGenIngreso = value;
                    RaisePropertyChanged("LabelIdTipoGenIngreso");
                }
            }
        }
        public short LabelIdGenIngreso
        {
            get { return _LabelIdGenIngreso; }
            set
            {
                if (value != null)
                {
                    _LabelIdGenIngreso = value;
                    RaisePropertyChanged("LabelIdGenIngreso");
                }
            }
        }
        public string LabelActivo
        {
            get { return _LabelActivo; }
            set
            {
                if (value != null)
                {
                    _LabelActivo = value;
                    RaisePropertyChanged("LabelIdActivo");
                }
            }
        }
        public string LabelBorrado
        {
            get { return _LabelBorrado; }
            set
            {
                if (value != null)
                {
                    _LabelBorrado = value;
                    RaisePropertyChanged("LabelBorrado");
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

        public DateTime LabelFechaUltMod
        {
            get { return _LabelFechaUltMod; }
            set
            {
                if (value != null)
                {
                    _LabelFechaUltMod = value;
                    RaisePropertyChanged("LabelFechaULtMod");
                }
            }
        }
        public string LabelUsuarioReg
        {
            get { return _LabelUsuarioReg; }
            set
            {
                if (value != null)
                {
                    _LabelUsuarioReg = value;
                    RaisePropertyChanged("LabelUsuarioReg");
                }
            }
        }

        public string LabelUsuarioMod
        {
            get { return _LabelUsuarioMod; }
            set
            {
                if (value != null)
                {
                    _LabelUsuarioMod = value;
                    RaisePropertyChanged("LabelUsuarioMod");
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
                return _FicMetRegesarAlumnosListICommand = _FicMetRegesarAlumnosListICommand ??
                    new FicVmDelegateCommand(FicMetRegresarAlumnos);
            }
        }

        private async void FicMetRegresarAlumnos()
        {
            try
            {
                IFicSrvNavigationEdificiosList.FicMetNavigateTo<FicVmAlumnoCarreraList>(FicNavigationContextC);
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
                var RespuestaInsert = await IFicSrvAlumnoCarreraAdd.InsertAlumnos(new eva_alumnos_carreras()
                {
                    IdCarrera = LabelIdCarrera,                   
                    IdAlumno = LabelIdAlumno,
                    IdReticula = LabelIdReticula,
                    IdEspecialidad = LabelIdEspecialidad,
                    FechaIngreso = LabelFechaIngreso,
                    FechaEgreso = LabelFechaEgreso,
                    FechaTitulacion = LabelFechaTitulacion,
                    FechaUltModSII = LabelFechaUltModSII,
                    PromedioActual = LabelPromedioActual,
                    PromedioPeriodoAnt = LabelPromedioPeriodoAnt,
                    PromedioFinal = LabelPromedioFinal,
                    CreditosAprobados = LabelCreditosAprobados,
                    CreditosCursados = LabelCreditosCursados,
                    TotalPuntosVigentes = LabelTotalPuntosVigentes,
                    TotalPuntosGenerados = LabelTotalPuntosGenerados,
                    SemestreActual = LabelSemestreActual,
                    IdPeriodoIngreso = LabelIdPeriodoIngreso,
                    IdPeriodoUltimo = LabelIdPeriodoUltimo,
                    IdPeriodoTitulacion = LabelIdPeriodoTitulacion,

                    IdTipoGenPlanEstudio = LabelIdTipoGenPlanEstudio,
                    IdGenPlanEstudio = LabelIdGenPlanEstudio,
                    IdTipoGenOpcionTitulacion = LabelIdTipoGenOpcionTitulacion,
                    IdGenOpcionTitulacion = LabelIdGenOpcionTitulacion,
                    IdTipoGenNivelEscolar = LabelIdTipoGenNivelEscolar,
                    IdGenNivelEscolar = LabelIdGenNivelEscolar,
                    IdTipoGenIngreso = LabelIdTipoGenIngreso,
                    IdGenIngreso = LabelIdGenIngreso,

                    Activo = LabelActivo,
                    Borrado = LabelBorrado,
                    FechaReg = DateTime.Now,
                    UsuarioReg = "root",
                    FechaUltMod = DateTime.Now,
                    UsuarioMod = "root"
                });

                if (RespuestaInsert == "OK")
                {
                    await new Page().DisplayAlert("ADD", "¡INSERTADO CON EXITO!", "OK");
                    IFicSrvNavigationEdificiosList.FicMetNavigateTo<FicVmAlumnoCarreraList>(FicNavigationContextC);
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

