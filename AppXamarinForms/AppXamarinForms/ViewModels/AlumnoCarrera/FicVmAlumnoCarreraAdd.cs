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
using Syncfusion.SfAutoComplete.XForms;


namespace AppXamarinForms.ViewModels.AlumnoCarrera
{
    public class FicVmAlumnoCarreraAdd : INotifyPropertyChanged
    {
        private IFicSrvNavegationCatEdificiosList IFicSrvNavigationEdificiosList;
        private IFicSrvAlumnoCarreraAdd IFicSrvAlumnoCarreraAdd;

        private short _LabelIdAlumno;
        //CARRERA
        public List<string> _ListCarrera;
        public string _Carrera;
        public Int16 _CaIndex;
        //RETICULA
        public List<string> _ListReticula;
        public string _Reticula;
        public Int16 _ReIndex;
        //ESPECIALIDAD  
        public List<string> _ListEspecialidad;
        public string _Especialidad;
        public Int16 _EsIndex;

        //PERIODOS  
        public List<string> _ListPeriodo1;
        public string _Periodo1;
        public Int16 _P1Index;

        //ESPECIALIDAD  
        public List<string> _ListPeriodo2;
        public string _Periodo2;
        public Int16 _P2Index;

        //ESPECIALIDAD  
        public List<string> _ListPeriodo3;
        public string _Periodo3;
        public Int16 _P3Index;


        //ESPECIALIDAD  
        public List<string> _ListGen1;
        public string _Gen1;
        public Int16 _G1Index;

        public List<string> _ListGen2;
        public string _Gen2;
        public Int16 _G2Index;

        public List<string> _ListGen3;
        public string _Gen3;
        public Int16 _G3Index;

        public List<string> _ListGen4;
        public string _Gen4;
        public Int16 _G4Index;

        public List<string> _ListAlumno;
        public string _Alumno;
        public Int16 _AlIndex;

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
        
        
        private ICommand _FicMetRegesarAlumnosListICommand, _SaveCommand;

        public object[] FicNavigationContextC { get; set; }

        public FicVmAlumnoCarreraAdd(IFicSrvNavegationCatEdificiosList ficSrvNavigationEdificiosList, IFicSrvAlumnoCarreraAdd ficSrvAlumnoCarreraAdd)
        {
            this.IFicSrvNavigationEdificiosList = ficSrvNavigationEdificiosList;
            this.IFicSrvAlumnoCarreraAdd = ficSrvAlumnoCarreraAdd;

            _ListCarrera = GetListCarrera().Result;
            _ListReticula = GetListReticula().Result;
            _ListEspecialidad = GetListEspecialidad().Result;
            _ListPeriodo1 = GetListPeriodo1().Result;
            _ListPeriodo2 = GetListPeriodo2().Result;
            _ListPeriodo3 = GetListPeriodo3().Result;
            _ListGen1 = GetListGen1().Result;
            _ListGen2 = GetListGen2().Result;
            _ListGen3 = GetListGen3().Result;
            _ListGen4 = GetListGen4().Result;
            _ListAlumno = GetListAlumno().Result;
        }
        
       /* public short LabelIdAlumno
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
        }***/
        #region Alumno
        public async Task<List<string>> GetListAlumno()
        {
            var listaCarrera = await IFicSrvAlumnoCarreraAdd.FicMetGetListAlumno();
            List<string> aux = new List<string>();
            if (listaCarrera != null)
            {
                foreach (rh_cat_personas carreras in listaCarrera)
                {
                    aux.Add(carreras.Nombre);
                }
                return aux;
            }
            return null;
        }
        public List<string> ListAlumno
        {
            get { return _ListAlumno; }
            set
            {
                if (value != null)
                {
                    _ListAlumno = value;
                    RaisePropertyChanged("ListAlunmno");
                }
            }
        }
        public string Alumno
        {
            get { return _Alumno; }
            set
            {
                if (value != null)
                {
                    _Alumno = value;
                    FicGlobalValues.ALUMNO = value;
                    RaisePropertyChanged("Alumno");
                }
            }
        }
        public Int16 AlIndex
        {
            get { return _AlIndex; }
            set
            {
                _AlIndex = FicGlobalValues.ALUMNO_INDEX = value;
                RaisePropertyChanged("AlIndex");
            }
        }
        #endregion

        #region Carrera
        public async Task<List<string>> GetListCarrera()
        {
            var listaCarrera = await IFicSrvAlumnoCarreraAdd.FicMetGetListCarrera();
            List<string> aux = new List<string>();
            if (listaCarrera != null)
            {
                foreach (eva_cat_carreras carreras in listaCarrera)
                {
                    aux.Add(carreras.Alias);
                }
                return aux;
            }
            return null;
        }
        public List<string> ListCarrera
        {
            get { return _ListCarrera; }
            set{
                if (value != null)
                {
                    _ListCarrera = value;
                    RaisePropertyChanged("ListCarrera");
                }
            }
        }
        public string Carrera
        {
            get { return _Carrera; }
            set {
                if (value != null)
                {
                    _Carrera = value;
                    FicGlobalValues.CARRERA = value;
                    RaisePropertyChanged("Carrera");
                }
            }
        }
        public Int16 CaIndex
        {
            get { return _CaIndex; }
            set
            {
                _CaIndex = FicGlobalValues.CARRERA_INDEX = value;
                RaisePropertyChanged("CaIndex");
            }
        }
        #endregion

        #region Reticula
        public async Task<List<string>> GetListReticula()
        {
            var listaCarrera = await IFicSrvAlumnoCarreraAdd.FicMetGetListReticula();
            List<string> aux = new List<string>();
            if (listaCarrera != null)
            {
                foreach (eva_cat_reticulas carreras in listaCarrera)
                {
                    aux.Add(carreras.DesReticula);
                }
                return aux;
            }
            return null;
        }
        public List<string> ListReticula
        {
            get { return _ListReticula; }
            set
            {
                if (value != null)
                {
                    _ListReticula = value;
                    RaisePropertyChanged("ListReticula");
                }
            }
        }
        public string Reticula
        {
            get { return _Reticula; }
            set
            {
                if (value != null)
                {
                    _Reticula = value;
                    FicGlobalValues.RETICULA = value;
                    RaisePropertyChanged("Reticula");
                }
            }
        }
        public Int16 ReIndex
        {
            get { return _ReIndex; }
            set
            {
                _ReIndex = FicGlobalValues.RETICULA_INDEX = value;
                RaisePropertyChanged("ReIndex");
            }
        }
        #endregion

        #region Especialidad
        public async Task<List<string>> GetListEspecialidad()
        {
            var listaCarrera = await IFicSrvAlumnoCarreraAdd.FicMetGetListEspecialidad();
            List<string> aux = new List<string>();
            if (listaCarrera != null)
            {
                foreach (eva_cat_especialidades carreras in listaCarrera)
                {
                    aux.Add(carreras.DesEspecialidad);
                }
                return aux;
            }
            return null;
        }
        public List<string> ListEspecialidad
        {
            get { return _ListEspecialidad; }
            set
            {
                if (value != null)
                {
                    _ListEspecialidad = value;
                    RaisePropertyChanged("ListEspecialidad");
                }
            }
        }
        public string Especialidad
        {
            get { return _Especialidad; }
            set
            {
                if (value != null)
                {
                    _Especialidad = value;
                    FicGlobalValues.ESPECIALIDAD = value;
                    RaisePropertyChanged("Especialidad");
                }
            }
        }
        public Int16 EsIndex
        {
            get { return _EsIndex; }
            set
            {
                _EsIndex = FicGlobalValues.ESPECIALIDAD_INDEX = value;
                RaisePropertyChanged("EsIndex");
            }
        }
        #endregion

        #region PeriocoActual        
        public async Task<List<string>> GetListPeriodo1()
        {
            var listaCarrera = await IFicSrvAlumnoCarreraAdd.FicMetGetListPeriodo1();
            List<string> aux = new List<string>();
            if (listaCarrera != null)
            {
                foreach (cat_periodos carreras in listaCarrera)
                {
                    aux.Add(carreras.DesPeriodo);
                }
                return aux;
            }
            return null;
        }
        public List<string> ListPeriodo1
        {
            get { return _ListPeriodo1; }
            set
            {
                if (value != null)
                {
                    _ListPeriodo1 = value;
                    RaisePropertyChanged("ListPeriodo1");
                }
            }
        }
        public string Periodo1
        {
            get { return _Periodo1; }
            set
            {
                if (value != null)
                {
                    _Periodo1 = value;
                    FicGlobalValues.PERIODO1 = value;
                    RaisePropertyChanged("Periodo1");
                }
            }
        }
        public Int16 P1Index
        {
            get { return _P1Index; }
            set
            {
                _P1Index = FicGlobalValues.PERIODO1_INDEX = value;
                RaisePropertyChanged("P1Index");
            }
        }
        #endregion

        #region PeriocoAnt        
        public async Task<List<string>> GetListPeriodo2()
        {
            var listaCarrera = await IFicSrvAlumnoCarreraAdd.FicMetGetListPeriodo2();
            List<string> aux = new List<string>();
            if (listaCarrera != null)
            {
                foreach (cat_periodos carreras in listaCarrera)
                {
                    aux.Add(carreras.DesPeriodo);
                }
                return aux;
            }
            return null;
        }
        public List<string> ListPeriodo2
        {
            get { return _ListPeriodo2; }
            set
            {
                if (value != null)
                {
                    _ListPeriodo2 = value;
                    RaisePropertyChanged("ListPeriodo2");
                }
            }
        }
        public string Periodo2
        {
            get { return _Periodo2; }
            set
            {
                if (value != null)
                {
                    _Periodo2 = value;
                    FicGlobalValues.PERIODO2 = value;
                    RaisePropertyChanged("Periodo2");
                }
            }
        }
        public Int16 P2Index
        {
            get { return _P2Index; }
            set
            {
                _P2Index = FicGlobalValues.PERIODO2_INDEX = value;
                RaisePropertyChanged("P2Index");
            }
        }
        #endregion

        #region PeriocoTitulo        
        public async Task<List<string>> GetListPeriodo3()
        {
            var listaCarrera = await IFicSrvAlumnoCarreraAdd.FicMetGetListPeriodo3();
            List<string> aux = new List<string>();
            if (listaCarrera != null)
            {
                foreach (cat_periodos carreras in listaCarrera)
                {
                    aux.Add(carreras.DesPeriodo);
                }
                return aux;
            }
            return null;
        }
        public List<string> ListPeriodo3
        {
            get { return _ListPeriodo3; }
            set
            {
                if (value != null)
                {
                    _ListPeriodo1 = value;
                    RaisePropertyChanged("ListPeriodo3");
                }
            }
        }
        public string Periodo3
        {
            get { return _Periodo3; }
            set
            {
                if (value != null)
                {
                    _Periodo3 = value;
                    FicGlobalValues.PERIODO3 = value;
                    RaisePropertyChanged("Periodo3");
                }
            }
        }
        public Int16 P3Index
        {
            get { return _P3Index; }
            set
            {
                _P3Index = FicGlobalValues.PERIODO3_INDEX = value;
                RaisePropertyChanged("P3Index");
            }
        }
        #endregion

        #region General1       
        public async Task<List<string>> GetListGen1()
        {
            var listaCarrera = await IFicSrvAlumnoCarreraAdd.FicMetGetListGen1();
            List<string> aux = new List<string>();
            if (listaCarrera != null)
            {
                foreach (cat_generales carreras in listaCarrera)
                {
                    aux.Add(carreras.DesGeneral);
                }
                return aux;
            }
            return null;
        }
        public List<string> ListGen1
        {
            get { return _ListGen1; }
            set
            {
                if (value != null)
                {
                    _ListGen1 = value;
                    RaisePropertyChanged("ListGen1");
                }
            }
        }
        public string Gen1
        {
            get { return _Gen1; }
            set
            {
                if (value != null)
                {
                    _Gen1 = value;
                    FicGlobalValues.GEN1 = value;
                    RaisePropertyChanged("Gen1");
                }
            }
        }
        public Int16 G1Index
        {
            get { return _G1Index; }
            set
            {
                _G1Index = FicGlobalValues.GEN1_INDEX = value;
                RaisePropertyChanged("G1Index");
            }
        }
        #endregion

        #region General2       
        public async Task<List<string>> GetListGen2()
        {
            var listaCarrera = await IFicSrvAlumnoCarreraAdd.FicMetGetListGen2();
            List<string> aux = new List<string>();
            if (listaCarrera != null)
            {
                foreach (cat_generales carreras in listaCarrera)
                {
                    aux.Add(carreras.DesGeneral);
                }
                return aux;
            }
            return null;
        }
        public List<string> ListGen2
        {
            get { return _ListGen2; }
            set
            {
                if (value != null)
                {
                    _ListGen1 = value;
                    RaisePropertyChanged("ListGen2");
                }
            }
        }
        public string Gen2
        {
            get { return _Gen2; }
            set
            {
                if (value != null)
                {
                    _Gen2 = value;
                    FicGlobalValues.GEN2 = value;
                    RaisePropertyChanged("Gen2");
                }
            }
        }
        public Int16 G2Index
        {
            get { return _G2Index; }
            set
            {
                _G2Index = FicGlobalValues.GEN2_INDEX = value;
                RaisePropertyChanged("G2Index");
            }
        }
        #endregion

        #region General3      
        public async Task<List<string>> GetListGen3()
        {
            var listaCarrera = await IFicSrvAlumnoCarreraAdd.FicMetGetListGen3();
            List<string> aux = new List<string>();
            if (listaCarrera != null)
            {
                foreach (cat_generales carreras in listaCarrera)
                {
                    aux.Add(carreras.DesGeneral);
                }
                return aux;
            }
            return null;
        }
        public List<string> ListGen3
        {
            get { return _ListGen3; }
            set
            {
                if (value != null)
                {
                    _ListGen3 = value;
                    RaisePropertyChanged("ListGen3");
                }
            }
        }
        public string Gen3
        {
            get { return _Gen3; }
            set
            {
                if (value != null)
                {
                    _Gen3 = value;
                    FicGlobalValues.GEN3 = value;
                    RaisePropertyChanged("Gen3");
                }
            }
        }
        public Int16 G3Index
        {
            get { return _G3Index; }
            set
            {   
                _G3Index = FicGlobalValues.GEN3_INDEX = value;
                RaisePropertyChanged("G3Index");
            }
        }
        #endregion

        #region General4      
        public async Task<List<string>> GetListGen4()
        {
            var listaCarrera = await IFicSrvAlumnoCarreraAdd.FicMetGetListGen4();
            List<string> aux = new List<string>();
            if (listaCarrera != null)
            {
                foreach (cat_generales carreras in listaCarrera)
                {                    
                    aux.Add(carreras.DesGeneral);
                }
                return aux;
            }
            return null;
        }
        public List<string> ListGen4
        {
            get { return _ListGen4; }
            set
            {
                if (value != null)
                {
                    _ListGen4 = value;
                    RaisePropertyChanged("ListGen4");
                }
            }
        }
        public string Gen4
        {
            get { return _Gen4; }
            set
            {
                if (value != null)
                {
                    _Gen4 = value;
                    FicGlobalValues.GEN4 = value;
                    RaisePropertyChanged("Gen4");
                }
            }
        }
        public Int16 G4Index
        {
            get { return _G4Index; }
            set
            {
                _G4Index = FicGlobalValues.GEN4_INDEX = value;
                RaisePropertyChanged("G4Index");
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
                    _LabelFechaUltModSII = value;
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
        
        
        public async void OnAppearing()
        {

        }

        public ICommand FicMetRegesarAlumnoListICommand
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
                        IdCarrera = Convert.ToInt16(CaIndex+1),
                        IdAlumno = Convert.ToInt16(AlIndex+1),
                        IdReticula = Convert.ToInt16(ReIndex+1),
                        IdEspecialidad = Convert.ToInt16(EsIndex +1),

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

                        IdPeriodoIngreso = Convert.ToInt16(P1Index + 1),
                        IdPeriodoUltimo = Convert.ToInt16(P2Index +1),
                        IdPeriodoTitulacion = Convert.ToInt16(P3Index +1),

                        IdTipoGenPlanEstudio = 25,
                        IdGenPlanEstudio = Convert.ToInt16(G1Index + 1),
                        IdTipoGenOpcionTitulacion = 27,
                        IdGenOpcionTitulacion = Convert.ToInt16(G2Index+1),
                        IdTipoGenNivelEscolar = 17,
                        IdGenNivelEscolar = Convert.ToInt16(G3Index+1),
                        IdTipoGenIngreso = 28,
                        IdGenIngreso = Convert.ToInt16(G4Index+1),

                        Activo = LabelActivo,
                        Borrado = LabelBorrado,
                        FechaReg = DateTime.Now,
                        UsuarioReg = "root",
                        FechaUltMod = DateTime.Now,
                        UsuarioMod = ""
                    });

                    if (RespuestaInsert == "OK")
                    {
                        await new Page().DisplayAlert("ADD", "¡INSERTADO CON EXITO!", "OK");
                        IFicSrvNavigationEdificiosList.FicMetNavigateTo<FicVmAlumnoCarreraList>(FicNavigationContextC);
                    }else { await new Page().DisplayAlert("ADD", RespuestaInsert.ToString(), "OK"); }//SE INSERTO EL CONTEO?                
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

