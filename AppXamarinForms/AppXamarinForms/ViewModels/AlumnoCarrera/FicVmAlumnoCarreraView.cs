using AppXamarinForms.Interface.Navegacion;
using AppXamarinForms.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

using AppXamarinForms.Models;
using AppXamarinForms.Data;
using AppXamarinForms.Interface.AlumnoCarrera;

namespace AppXamarinForms.ViewModels.AlumnoCarrera
{
    public class FicVmAlumnoCarreraView: INotifyPropertyChanged
    
    {
        private IFicSrvNavegationCatEdificiosList IFicSrvNavegationCatEdificiosList;
        private IFicSvrAlumnoCarreraList ficSvrAlumnoCarreraList;

        private string _LabelIdCarrera;
        private string _LabelIdAlumno;
        private string _LabelIdReticula;
        private string _LabelIdEspecialidad;
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
        private string _LabelIdPeriodoIngreso;
        private string _LabelIdPeriodoUltimo;
        private string _LabelIdPeriodoTitulacion;

        private short _LabelIdTipoGenPlanEstudio;
        private string _LabelIdGenPlanEstudio;
        private short _LabelIdTipoGenOpcionTitulacion;
        private string _LabelIdGenOpcionTitulacion;
        private short _LabelIdTipoGenNivelEscolar;
        private string _LabelIdGenNivelEscolar;
        private short _LabelIdTipoGenIngreso;
        private string _LabelIdGenIngreso;

        private string _LabelActivo;
        private string _LabelBorrado;
        private DateTime _LabelFechaReg;
        private string _LabelUsuarioReg;
        private DateTime _LabelFechaUltMod;
        private string _LabelUsuarioMod;

        private ICommand _FicMetRegesarAlumnoListICommand;

        public object FicNavigationContextC { get; set; }


        public FicVmAlumnoCarreraView(IFicSrvNavegationCatEdificiosList IFicSrvNavegationCatEdificiosList, 
            IFicSvrAlumnoCarreraList ficSvrAlumnoCarreraList)
        {
            this.ficSvrAlumnoCarreraList = ficSvrAlumnoCarreraList;
            this.IFicSrvNavegationCatEdificiosList = IFicSrvNavegationCatEdificiosList;
        }
        public string LabelIdCarrera
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

        public string LabelIdAlumno
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


        public string LabelIdReticula
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
        public string LabelIdEspecialidad
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
        public string LabelIdPeriodoIngreso
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
        public string LabelIdPeriodoUltimo
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
        public string LabelIdPeriodoTitulacion
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
        public string LabelIdGenPlanEstudio
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
        public string LabelIdGenOpcionTitulacion
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
        public string LabelIdGenNivelEscolar
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
        public string LabelIdGenIngreso
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
            rh_cat_personas cat_aux = ficSvrAlumnoCarreraList.FicMetGetListAlumno(source_eva_alumnos_carreras.IdAlumno).Result;
            eva_cat_carreras carreras = ficSvrAlumnoCarreraList.FicMetGetListCarrera(source_eva_alumnos_carreras.IdCarrera).Result;
            eva_cat_reticulas reti = ficSvrAlumnoCarreraList.FicMetGetListReticula(source_eva_alumnos_carreras.IdReticula).Result;
            eva_cat_especialidades espe = ficSvrAlumnoCarreraList.FicMetGetListEspecialidad(source_eva_alumnos_carreras.IdEspecialidad).Result;
            cat_generales ge1 = ficSvrAlumnoCarreraList.FicMetGetListGen1(source_eva_alumnos_carreras.IdGenPlanEstudio).Result;
            cat_generales ge2 = ficSvrAlumnoCarreraList.FicMetGetListGen2(source_eva_alumnos_carreras.IdGenOpcionTitulacion).Result;
            cat_generales ge3 = ficSvrAlumnoCarreraList.FicMetGetListGen1(source_eva_alumnos_carreras.IdGenNivelEscolar).Result;
            cat_generales ge4 = ficSvrAlumnoCarreraList.FicMetGetListGen1(source_eva_alumnos_carreras.IdGenIngreso).Result;
            cat_periodos pe1 = ficSvrAlumnoCarreraList.FicMetGetListPeriodo1(source_eva_alumnos_carreras.IdPeriodoIngreso).Result;
            cat_periodos pe2 = ficSvrAlumnoCarreraList.FicMetGetListPeriodo2(source_eva_alumnos_carreras.IdPeriodoUltimo).Result;
            cat_periodos pe3 = ficSvrAlumnoCarreraList.FicMetGetListPeriodo1(source_eva_alumnos_carreras.IdPeriodoTitulacion).Result;


            _LabelIdCarrera = carreras.Alias;
            _LabelIdAlumno = cat_aux.Nombre;
            _LabelIdReticula = reti.DesReticula;
            _LabelIdEspecialidad = espe.DesEspecialidad;
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
            _LabelIdPeriodoIngreso = pe1.DesPeriodo;
            _LabelIdPeriodoUltimo = pe2.DesPeriodo;
            _LabelIdPeriodoTitulacion = pe3.DesPeriodo;

            _LabelIdTipoGenPlanEstudio = source_eva_alumnos_carreras.IdTipoGenPlanEstudio;
            _LabelIdGenPlanEstudio = ge1.DesGeneral;
            _LabelIdTipoGenOpcionTitulacion = source_eva_alumnos_carreras.IdTipoGenOpcionTitulacion;
            _LabelIdGenOpcionTitulacion = ge2.DesGeneral;
            _LabelIdTipoGenNivelEscolar = source_eva_alumnos_carreras.IdTipoGenNivelEscolar;
            _LabelIdGenNivelEscolar = ge3.DesGeneral;
            _LabelIdTipoGenIngreso = source_eva_alumnos_carreras.IdTipoGenIngreso;
            _LabelIdGenIngreso = ge4.DesGeneral;

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

        public ICommand FicMetRegesarAlumnoListICommand
        {
            get
            {
                return _FicMetRegesarAlumnoListICommand = _FicMetRegesarAlumnoListICommand ??
                    new FicVmDelegateCommand(FicMetRegresarAlumno);
            }
        }

        private async void FicMetRegresarAlumno()
        {
            try
            {
                IFicSrvNavegationCatEdificiosList.FicMetNavigateTo<FicVmAlumnoCarreraList>(FicNavigationContextC);
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