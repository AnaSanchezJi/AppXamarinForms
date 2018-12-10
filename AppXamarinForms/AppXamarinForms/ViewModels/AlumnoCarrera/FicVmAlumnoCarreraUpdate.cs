using AppXamarinForms.Interface.AlumnoCarrera;
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

namespace AppXamarinForms.ViewModels.AlumnoCarrera
{
    public class FicVmAlumnoCarreraUpdate : INotifyPropertyChanged
    {
        private IFicSrvNavegationCatEdificiosList IFicSrvNavigationEdificios;
        private IFicSrvAlumnoCarreraUpdate IFicSrvAlumnoCarreraUpdate;

        private short _LabelIdCarrera;
        private int _LabelIdAlumno;
        private int _LabelIdReticula;
        private short _LabelIdEspecialidad;
        private DateTime _LabelFechaIngreso;
        private DateTime _LabelFechaEgreso;
        private DateTime _LabelFechaTitulacion;
        private DateTime _LabelFechaUltModSII;
        private double _LabelPromedioActual;
        private int _LabelPromedioPeriodoAnt;
        private double _LabelPromedioFinal;
        private double _LabelCreditosAprobados;
        private double _LabelCreditosCursados;
        private double _LabelTotalPuntosVigentes;
        private double _LabelTotalPuntosGenerados;
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

        public object FicNavigationContextC { get; set; }

        public FicVmAlumnoCarreraUpdate(IFicSrvNavegationCatEdificiosList IFicSrvNavigationEdificios, IFicSrvAlumnoCarreraUpdate IFicSrvAlumnoCarreraUpdate)
        {
            this.IFicSrvNavigationEdificios = IFicSrvNavigationEdificios;
            this.IFicSrvAlumnoCarreraUpdate = IFicSrvAlumnoCarreraUpdate;
        }

        public short LabelIdCarrera
        {
            get { return _LabelIdCarrera; }
            set
            {
                if (value != null)
                {
                    _LabelIdCarrera = value;
                    RaisePropertyChanged("LabelIdCarrera");
                }
            }
        }

        public int LabelIdAlumno
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
        public double LabelPromedioActual
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
        public double LabelPromedioFinal
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
        public double LabelCreditosAprobados
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
        public double LabelCreditosCursados
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
        public double LabelTotalPuntosVigentes
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
        public double LabelTotalPuntosGenerados
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
            var source_eva_alumnos_carreras = FicNavigationContextC as eva_alumnos_carreras;
            _LabelIdCarrera = source_eva_alumnos_carreras.IdCarrera;
            _LabelIdAlumno = source_eva_alumnos_carreras.IdAlumno;
            _LabelIdReticula = source_eva_alumnos_carreras.IdEspecialidad;
            _LabelIdEspecialidad = source_eva_alumnos_carreras.IdEspecialidad;
            _LabelFechaIngreso = source_eva_alumnos_carreras.FechaIngreso;
            _LabelFechaEgreso = source_eva_alumnos_carreras.FechaEgreso;
            _LabelFechaTitulacion = source_eva_alumnos_carreras.FechaTitulacion;
            _LabelFechaUltModSII = source_eva_alumnos_carreras.FechaUltModSII;
            _LabelPromedioActual = source_eva_alumnos_carreras.PromedioActual;
            _LabelPromedioPeriodoAnt = source_eva_alumnos_carreras.PromedioPeriodoAnt;
            _LabelPromedioFinal = source_eva_alumnos_carreras.PromedioFinal;
            _LabelCreditosAprobados = source_eva_alumnos_carreras.CreditosAprobados;
            _LabelCreditosCursados = source_eva_alumnos_carreras.CreditosCursados;
            _LabelTotalPuntosVigentes = source_eva_alumnos_carreras.TotalPuntosVigentes;
            _LabelTotalPuntosGenerados = source_eva_alumnos_carreras.TotalPuntosGenerados;
            _LabelSemestreActual = source_eva_alumnos_carreras.SemestreActual;
            _LabelIdPeriodoIngreso = source_eva_alumnos_carreras.IdPeriodoIngreso;
            _LabelIdPeriodoUltimo = source_eva_alumnos_carreras.IdPeriodoUltimo;
            _LabelIdPeriodoTitulacion = source_eva_alumnos_carreras.IdPeriodoTitulacion;

            _LabelIdTipoGenPlanEstudio = source_eva_alumnos_carreras.IdTipoGenPlanEstudio;
            _LabelIdGenPlanEstudio = source_eva_alumnos_carreras.IdGenPlanEstudio;
            _LabelIdTipoGenOpcionTitulacion = source_eva_alumnos_carreras.IdTipoGenOpcionTitulacion;
            _LabelIdGenOpcionTitulacion = source_eva_alumnos_carreras.IdGenOpcionTitulacion;
            _LabelIdTipoGenNivelEscolar = source_eva_alumnos_carreras.IdTipoGenNivelEscolar;
            _LabelIdGenNivelEscolar = source_eva_alumnos_carreras.IdTipoGenNivelEscolar;
            _LabelIdTipoGenIngreso = source_eva_alumnos_carreras.IdTipoGenIngreso;
            _LabelIdGenIngreso = source_eva_alumnos_carreras.IdTipoGenIngreso;

            _LabelActivo = source_eva_alumnos_carreras.Activo;
            _LabelBorrado = source_eva_alumnos_carreras.Borrado;
            _LabelFechaReg = source_eva_alumnos_carreras.FechaReg;
            _LabelUsuarioReg = source_eva_alumnos_carreras.UsuarioReg;
            _LabelFechaUltMod = source_eva_alumnos_carreras.FechaUltMod;
            _LabelUsuarioMod = source_eva_alumnos_carreras.UsuarioMod;

            RaisePropertyChanged("LabelIdCarrera");
            RaisePropertyChanged("LabelIdAlumno");
            RaisePropertyChanged("LabelIdReticula");
            RaisePropertyChanged("LabelIdEspecialidad");
            RaisePropertyChanged("LabelFechaIngreso");
            RaisePropertyChanged("LabelFechaEgreso");
            RaisePropertyChanged("LabelFechaTitulacion");
            RaisePropertyChanged("LabelFechaUltModSII");
            RaisePropertyChanged("LabelPromedioActual");
            RaisePropertyChanged("LabelPromedioPeriodoAnt");
            RaisePropertyChanged("LabelPromedioFinal");
            RaisePropertyChanged("LabelCreditosAprobados");
            RaisePropertyChanged("LabelCreditosCursados");
            RaisePropertyChanged("LabelTotalPuntosVigentes");
            RaisePropertyChanged("LabelTotalPuntosGenerados");
            RaisePropertyChanged("LabelSemestreActual");
            RaisePropertyChanged("LabelIdPeriodoIngreso");
            RaisePropertyChanged("LabelIdPeriodoUltimo");
            RaisePropertyChanged("LabelIdPeriodoTitulacion");
            RaisePropertyChanged("LabelIdTipoGenPlanEstudio");
            RaisePropertyChanged("LabelIdGenPlanEstudio");
            RaisePropertyChanged("LabelIdTipoGenOpcionTitulacion");
            RaisePropertyChanged("LabelIdGenOpcionTitulacion");
            RaisePropertyChanged("LabelIdTipoGenNivelEscolar");
            RaisePropertyChanged("LabelIdGenNivelEscolar");
            RaisePropertyChanged("LabelIdTipoGenIngreso");
            RaisePropertyChanged("LabelIdGenIngreso");
            RaisePropertyChanged("LabelActivo");
            RaisePropertyChanged("LabelBorrado");
            RaisePropertyChanged("LabelFechaReg");
            RaisePropertyChanged("LabelUsuarioReg");
            RaisePropertyChanged("LabelFechaUltMod");
            RaisePropertyChanged("LabelUsuarioMod");


        }

        #region MANEJO DE COMANDOS        
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
                IFicSrvNavigationEdificios.FicMetNavigateTo<FicVmAlumnoCarreraList>(FicNavigationContextC);
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
            var source_eva_alumnos_carreras = FicNavigationContextC as eva_alumnos_carreras;
            try
            {
                var RespuestaInsert = await IFicSrvAlumnoCarreraUpdate.UpdateAlumno(new eva_alumnos_carreras()
                {
                IdCarrera = LabelIdCarrera,
                IdAlumno = source_eva_alumnos_carreras.IdAlumno,
                IdReticula = LabelIdEspecialidad,
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
                IdGenNivelEscolar = LabelIdTipoGenNivelEscolar,
                IdTipoGenIngreso = LabelIdTipoGenIngreso,
                IdGenIngreso = LabelIdTipoGenIngreso,

                Activo = LabelActivo,
                Borrado = LabelBorrado,
                FechaReg = source_eva_alumnos_carreras.FechaReg,
                UsuarioReg = source_eva_alumnos_carreras.UsuarioReg,
                FechaUltMod = DateTime.Now,
                UsuarioMod = "Ana"
                
                });

                if (RespuestaInsert == "OK")
                {
                    await new Page().DisplayAlert("ADD", "¡EDITADO CON EXITO!", "OK");
                    IFicSrvNavigationEdificios.FicMetNavigateTo<FicVmAlumnoCarreraList>(FicNavigationContextC);
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
