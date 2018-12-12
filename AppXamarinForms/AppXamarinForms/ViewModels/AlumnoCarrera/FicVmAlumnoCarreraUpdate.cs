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
using System.Threading.Tasks;
using AppXamarinForms.Data;

namespace AppXamarinForms.ViewModels.AlumnoCarrera
{
    public class FicVmAlumnoCarreraUpdate : INotifyPropertyChanged
    {
        private IFicSrvNavegationCatEdificiosList IFicSrvNavigationEdificios;
        private IFicSrvAlumnoCarreraUpdate IFicSrvAlumnoCarreraUpdate;

        private int _LabelIdAlumno;
        public Int16 _CarreraId;        
        private List<string> _Carrera;
        public Int16 _ReticulaId;
        private List<string> _Reticula;   
        public Int16 _EspecialidadId;
        private List<string> _Especialidad;        
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
        public Int16 _PeriodoIngresoId;
        private List<string> _PeriodoIngreso;        
        public Int16 _PeriodoUltimoId;
        private List<string> _PeriodoUltimo;
        private short _LabelIdPeriodoTitulacion;
        public Int16 _PeriodoTitulacionId;
        private List<string> _PeriodoTitulacion;
        private short _LabelIdTipoGenPlanEstudio;
        public Int16 _PlanEstudioId;
        private List<string> _PlanEstudio;
        private short _LabelIdTipoGenOpcionTitulacion;        
        public Int16 _OpcionTitulacionId;
        private List<string> _OpcionTitulacion;
        private short _LabelIdTipoGenNivelEscolar;        
        public Int16 _NivelEscolarId;
        private List<string> _NivelEscolar;
        private short _LabelIdTipoGenIngreso;
        public Int16 _IngresoId;
        private List<string> _Ingreso;

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

            _Carrera = GetListCarrera().Result;
            _Reticula = GetListReticula().Result;
            _Especialidad = GetListEspecialidad().Result;
            _PeriodoIngreso = GetListP1().Result;
            _PeriodoUltimo = GetListP2().Result;
            _PeriodoTitulacion = GetListP3().Result;
            _PlanEstudio = GetListG1().Result;
            _OpcionTitulacion = GetListG2().Result;
            _NivelEscolar = GetListG3().Result;
            _Ingreso = GetListG4().Result;
        }

        #region CA
        public async Task<List<string>> GetListCarrera()
        {
            try
            {
                var periodos = await IFicSrvAlumnoCarreraUpdate.FicMetGetListCarrera();
                if (periodos != null)
                {
                    List<string> aux = new List<string>();
                    foreach (eva_cat_carreras per in periodos)
                    {
                        aux.Add(per.Alias);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }

        }
        public List<string> Carrera
        {
            get { return _Carrera; }
            set
            {
                _Carrera = value;
                RaisePropertyChanged("Carrera");
            }
        }
        public Int16 CarreraId
        {
            get
            {
                return _CarreraId;
            }
            set
            {
                _CarreraId = value;
                FicGlobalValues.CARRERA_INDEX = value;
                RaisePropertyChanged("CarreraId");
            }
        }
        #endregion
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
        #region Reticula
        public async Task<List<string>> GetListReticula()
        {
            try
            {
                var periodos = await IFicSrvAlumnoCarreraUpdate.FicMetGetListReticula();
                if (periodos != null)
                {
                    List<string> aux = new List<string>();
                    foreach (eva_cat_reticulas per in periodos)
                    {
                        aux.Add(per.DesReticula);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }

        }
        public List<string> Reticula
        {
            get { return _Reticula; }
            set
            {
                _Reticula = value;
                RaisePropertyChanged("Reticula");
            }
        }
        public Int16 ReticulaId
        {
            get
            {
                return _ReticulaId;
            }
            set
            {
                _ReticulaId = value;
                FicGlobalValues.RETICULA_INDEX = value;
                RaisePropertyChanged("ReticulaId");
            }
        }
        #endregion
        #region Especialidad
        public async Task<List<string>> GetListEspecialidad()
        {
            try
            {
                var periodos = await IFicSrvAlumnoCarreraUpdate.FicMetGetListEspecialidad();
                if (periodos != null)
                {
                    List<string> aux = new List<string>();
                    foreach (eva_cat_especialidades per in periodos)
                    {
                        aux.Add(per.DesEspecialidad);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }

        }
        public List<string> Especialidad
        {
            get { return _Especialidad; }
            set
            {
                _Especialidad = value;
                RaisePropertyChanged("Especialidad");
            }
        }
        public Int16 EspecialidadId
        {
            get
            {
                return _EspecialidadId;
            }
            set
            {
                _EspecialidadId = value;
                FicGlobalValues.ESPECIALIDAD_INDEX = value;
                RaisePropertyChanged("ReticulaId");
            }
        }
        #endregion
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
        #region P1
        public async Task<List<string>> GetListP1()
        {
            try
            {
                var periodos = await IFicSrvAlumnoCarreraUpdate.FicMetGetListPeriodo1();
                if (periodos != null)
                {
                    List<string> aux = new List<string>();
                    foreach (cat_periodos per in periodos)
                    {
                        aux.Add(per.DesPeriodo);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }

        }
        public List<string> PeriodoIngreso
        {
            get { return _PeriodoIngreso; }
            set
            {
                _PeriodoIngreso = value;
                RaisePropertyChanged("PeriodoIngreso");
            }
        }
        public Int16 PeriodoIngresoId
        {
            get
            {
                return _PeriodoIngresoId;
            }
            set
            {
                _PeriodoIngresoId = value;
                FicGlobalValues.PERIODO1_INDEX= value;
                RaisePropertyChanged("PeriodoIngresoId");
            }
        }
        #endregion
        #region P2
        public async Task<List<string>> GetListP2()
        {
            try
            {
                var periodos = await IFicSrvAlumnoCarreraUpdate.FicMetGetListPeriodo2();
                if (periodos != null)
                {
                    List<string> aux = new List<string>();
                    foreach (cat_periodos per in periodos)
                    {
                        aux.Add(per.DesPeriodo);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }

        }
        public List<string> PeriodoUltimo
        {
            get { return _PeriodoUltimo; }
            set
            {
                _PeriodoUltimo = value;
                RaisePropertyChanged("PeriodoUltimo");
            }
        }
        public Int16 PeriodoUltimoId
        {
            get
            {
                return _PeriodoUltimoId;
            }
            set
            {
                _PeriodoUltimoId = value;
                FicGlobalValues.PERIODO2_INDEX = value;
                RaisePropertyChanged("PeriodoUltimoId");
            }
        }
        #endregion
        #region P3
        public async Task<List<string>> GetListP3()
        {
            try
            {
                var periodos = await IFicSrvAlumnoCarreraUpdate.FicMetGetListPeriodo3();
                if (periodos != null)
                {
                    List<string> aux = new List<string>();
                    foreach (cat_periodos per in periodos)
                    {
                        aux.Add(per.DesPeriodo);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }

        }
        public List<string> PeriodoTitulacion
        {
            get { return _PeriodoTitulacion; }
            set
            {
                _PeriodoTitulacion = value;
                RaisePropertyChanged("PeriodoUltimo");
            }
        }
        public Int16 PeriodoTitulacionId
        {
            get
            {
                return _PeriodoTitulacionId;
            }
            set
            {
                _PeriodoTitulacionId = value;
                FicGlobalValues.PERIODO3_INDEX = value;
                RaisePropertyChanged("PeriodoTitulacionId");
            }
        }
        #endregion
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
        #region G1
        public async Task<List<string>> GetListG1()
        {
            try
            {
                var periodos = await IFicSrvAlumnoCarreraUpdate.FicMetGetListGen1();
                if (periodos != null)
                {
                    List<string> aux = new List<string>();
                    foreach (cat_generales per in periodos)
                    {
                        aux.Add(per.DesGeneral);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }

        }
        public List<string> PlanEstudio
        {
            get { return _PlanEstudio; }
            set
            {
                _PlanEstudio = value;
                RaisePropertyChanged("PlanEstudio");
            }
        }
        public Int16 PlanEstudioId
        {
            get
            {
                return _PlanEstudioId;
            }
            set
            {
                _PlanEstudioId = value;
                FicGlobalValues.GEN1_INDEX = value;
                RaisePropertyChanged("PlanEstudioId");
            }
        }
        #endregion
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
        #region G2
        public async Task<List<string>> GetListG2()
        {
            try
            {
                var periodos = await IFicSrvAlumnoCarreraUpdate.FicMetGetListGen2();
                if (periodos != null)
                {
                    List<string> aux = new List<string>();
                    foreach (cat_generales per in periodos)
                    {
                        aux.Add(per.DesGeneral);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }

        }
        public List<string> OpcionTitulacion
        {
            get { return _OpcionTitulacion; }
            set
            {
                _OpcionTitulacion = value;
                RaisePropertyChanged("OpcionTitulacion");
            }
        }
        public Int16 OpcionTitulacionId
        {
            get
            {
                return _OpcionTitulacionId;
            }
            set
            {
                _OpcionTitulacionId = value;
                FicGlobalValues.GEN2_INDEX = value;
                RaisePropertyChanged("OpcionTitulacionId");
            }
        }
        #endregion        
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
        #region G3
        public async Task<List<string>> GetListG3()
        {
            try
            {
                var periodos = await IFicSrvAlumnoCarreraUpdate.FicMetGetListGen3();
                if (periodos != null)
                {
                    List<string> aux = new List<string>();
                    foreach (cat_generales per in periodos)
                    {
                        aux.Add(per.DesGeneral);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }

        }
        public List<string> NivelEscolar
        {
            get { return _NivelEscolar; }
            set
            {
                _NivelEscolar = value;
                RaisePropertyChanged("NivelEscolar");
            }
        }
        public Int16 NivelEscolarId
        {
            get
            {
                return _NivelEscolarId;
            }
            set
            {
                _NivelEscolarId = value;
                FicGlobalValues.GEN3_INDEX = value;
                RaisePropertyChanged("NivelEscolarId");
            }
        }
        #endregion                
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
        #region G3
        public async Task<List<string>> GetListG4()
        {
            try
            {
                var periodos = await IFicSrvAlumnoCarreraUpdate.FicMetGetListGen4();
                if (periodos != null)
                {
                    List<string> aux = new List<string>();
                    foreach (cat_generales per in periodos)
                    {
                        aux.Add(per.DesGeneral);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }

        }
        public List<string> Ingreso
        {
            get { return _Ingreso; }
            set
            {
                _NivelEscolar = value;
                RaisePropertyChanged("Ingreso");
            }
        }
        public Int16 IngresoId
        {
            get
            {
                return _IngresoId;
            }
            set
            {
                _IngresoId = value;
                FicGlobalValues.GEN4_INDEX = value;
                RaisePropertyChanged("IngresoId");
            }
        }
        #endregion                
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
            _CarreraId = (Int16)(source_eva_alumnos_carreras.IdCarrera-1);      
            _LabelIdAlumno = source_eva_alumnos_carreras.IdAlumno;
            _ReticulaId =(Int16)(source_eva_alumnos_carreras.IdEspecialidad-1);
            _EspecialidadId = (Int16)(source_eva_alumnos_carreras.IdEspecialidad-1);
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
            _PeriodoIngresoId =(Int16) (source_eva_alumnos_carreras.IdPeriodoIngreso-1);
            _PeriodoUltimoId =(Int16) (source_eva_alumnos_carreras.IdPeriodoUltimo-1);
            _PeriodoTitulacionId = (Int16) (source_eva_alumnos_carreras.IdPeriodoTitulacion-1);
            _LabelIdTipoGenPlanEstudio = source_eva_alumnos_carreras.IdTipoGenPlanEstudio;
            _PlanEstudioId = (Int16)(source_eva_alumnos_carreras.IdGenPlanEstudio-1);
            _LabelIdTipoGenOpcionTitulacion = source_eva_alumnos_carreras.IdTipoGenOpcionTitulacion;
            _OpcionTitulacionId = (Int16)(source_eva_alumnos_carreras.IdGenOpcionTitulacion-1);
            _LabelIdTipoGenNivelEscolar = source_eva_alumnos_carreras.IdTipoGenNivelEscolar;
            _NivelEscolarId = (Int16)(source_eva_alumnos_carreras.IdTipoGenNivelEscolar-1);
            _LabelIdTipoGenIngreso = source_eva_alumnos_carreras.IdTipoGenIngreso;
            _IngresoId = (Int16)(source_eva_alumnos_carreras.IdTipoGenIngreso-1);

            _LabelActivo = source_eva_alumnos_carreras.Activo;
            _LabelBorrado = source_eva_alumnos_carreras.Borrado;
            _LabelFechaReg = source_eva_alumnos_carreras.FechaReg;
            _LabelUsuarioReg = source_eva_alumnos_carreras.UsuarioReg;
            _LabelFechaUltMod = source_eva_alumnos_carreras.FechaUltMod;
            _LabelUsuarioMod = source_eva_alumnos_carreras.UsuarioMod;

            RaisePropertyChanged("LabelIdAlumno");
            RaisePropertyChanged("CarreraId");            
            RaisePropertyChanged("ReticulaId");
            RaisePropertyChanged("EspecialidadId");
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
            RaisePropertyChanged("PeriodoIngresoId");
            RaisePropertyChanged("PeriodoUltimoId");
            RaisePropertyChanged("PeriodoTitulacionId");
            RaisePropertyChanged("LabelIdTipoGenPlanEstudio");
            RaisePropertyChanged("PlanEstudioId");
            RaisePropertyChanged("LabelIdTipoGenOpcionTitulacion");
            RaisePropertyChanged("OpcionTitulacionId");
            RaisePropertyChanged("LabelIdTipoGenNivelEscolar");
            RaisePropertyChanged("NivelEscolarId");
            RaisePropertyChanged("LabelIdTipoGenIngreso");
            RaisePropertyChanged("IngresoId");
            RaisePropertyChanged("LabelActivo");
            RaisePropertyChanged("LabelBorrado");
            RaisePropertyChanged("LabelFechaReg");
            RaisePropertyChanged("LabelUsuarioReg");
            RaisePropertyChanged("LabelFechaUltMod");
            RaisePropertyChanged("LabelUsuarioMod");


        }

        #region MANEJO DE COMANDOS        
        public ICommand FicMetRegesarAlumnosListICommand
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
                IdAlumno = source_eva_alumnos_carreras.IdAlumno,
                IdCarrera = (Int16)(this._CarreraId + 1),                
                IdReticula = this._ReticulaId+1,
                IdEspecialidad = (Int16)(this._EspecialidadId +1),
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

                IdPeriodoIngreso = (Int16)(this._PeriodoIngresoId + 1),
                IdPeriodoUltimo = (Int16)(this._PeriodoUltimoId + 1),
                IdPeriodoTitulacion = (Int16)(this._PeriodoUltimoId + 1),

                IdTipoGenPlanEstudio = 25,
                IdGenPlanEstudio = (Int16)(this._PlanEstudioId + 1),
                IdTipoGenOpcionTitulacion = 17,
                IdGenOpcionTitulacion = (Int16)(this._OpcionTitulacionId + 1),
                IdTipoGenNivelEscolar = 27,
                IdGenNivelEscolar = (Int16)(this._NivelEscolarId + 1),
                IdTipoGenIngreso = 28,
                IdGenIngreso = (Int16)(this._IngresoId + 1),

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
