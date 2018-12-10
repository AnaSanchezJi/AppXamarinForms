using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppXamarinForms.Models
{
    public class FicModels
    {
    }
    [Table("cat_tipos_generales")]
    public class cat_tipos_generales
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdTipoGeneral { get; set; }
        public String DesTipo { get; set; }
    }

    [Table("cat_generales")]
    public class cat_generales
    {       
        public Int16 IdGeneral { get; set; }
        public Int16 IdTipoGeneral { get; set; }       
        public string Clave { get; set; }
        public string DesGeneral { get; set; }
    }

    [Table("cat_periodos")]
    public class cat_periodos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdPeriodo { get; set; }
        public string DesPeriodo { get; set; }
        public string NombreCorto { get; set; }
        public DateTime PeriodoIni { get; set; }
        public DateTime PeriodoFin { get; set; }
        public Int16 Año { get; set; }
        public string NumPeriodo { get; set; }
    }

    [Table("eva_cat_reticulas")]
    public class eva_cat_reticulas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int32 IdReticula { get; set; }
        public string Clave { get; set; }
        public string DesReticula { get; set; }
        public string Actual { get; set; }
    }

    [Table("rh_cat_alumnos")]
    public class rh_cat_alumnos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int32 IdAlumno { get; set; }
        public string NumControl { get; set; }
        public DateTime FechaReg { get; set; }
    }

    [Table("rh_cat_personas")]
    public class rh_cat_personas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int32 IdPersona { get; set; }
        public Int16 IdInstituto { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
    }

    [Table("eva_cat_especialidades")]
    public class eva_cat_especialidades
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdEspecialidad { get; set; }
        public string DesEspecialidad { get; set; }
    }

    [Table("eva_alumnos_carreras")]
    public class eva_alumnos_carreras
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int32 IdAlumno { get; set; }
        public rh_cat_alumnos rh_cat_alumnos;
        public Int16 IdCarrera { get; set; }
        public eva_cat_carreras carreras;
        public Int32 IdReticula { get; set; }
        public eva_cat_reticulas eva_cat_reticulas { get; set; }
        public Int16 IdEspecialidad { get; set; }
        public eva_cat_especialidades eva_cat_especialidades { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
        public DateTime FechaTitulacion { get; set; }
        public DateTime FechaUltModSII { get; set; }
        public Double PromedioActual { get; set; }
        public Int32 PromedioPeriodoAnt { get; set; }
        public Double PromedioFinal { get; set; }
        public Double CreditosAprobados { get; set; }
        public Double CreditosCursados { get; set; }
        public Double TotalPuntosVigentes { get; set; }
        public Double TotalPuntosGenerados { get; set; }
        public Int16 SemestreActual { get; set; }

        public Int16 IdPeriodoIngreso { get; set; }
        public cat_periodos cat_periodosI { get; set; }
        public Int16 IdPeriodoUltimo { get; set; }
        public cat_periodos cat_periodosU { get; set; }
        public Int16 IdPeriodoTitulacion { get; set; }
        public cat_periodos cat_periodosT { get; set; }

        public Int16 IdTipoGenPlanEstudio { get; set; }
        public cat_tipos_generales tipo_generalPE {get; set;}       
        public Int16 IdGenPlanEstudio { get; set; }
        public cat_generales generalPE { get; set; }

        public Int16 IdTipoGenOpcionTitulacion { get; set; }
        public cat_tipos_generales tipo_generalT { get; set; }
        public Int16 IdGenOpcionTitulacion { get; set; }
        public cat_generales generalT { get; set; }

        public Int16 IdTipoGenNivelEscolar { get; set; }
        public cat_tipos_generales tipo_generalNE { get; set; }
        public Int16 IdGenNivelEscolar { get; set; }
        public cat_generales generalNE { get; set; }

        public Int16 IdTipoGenIngreso { get; set; }
        public cat_tipos_generales tipo_generalI { get; set; }
        public Int16 IdGenIngreso { get; set; }
        public cat_generales generalI { get; set; }


        public String Activo { get; set; }
        public String Borrado { get; set; }
        public DateTime FechaReg { get; set; }
        public String UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public String UsuarioMod { get; set; }
    }

    [Table("eva_cat_carreras")]
    public class eva_cat_carreras
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdCarrera { get; set; }
        public string ClaveCarrera { get; set; }
        public string ClaveOficial { get; set; }
        public string DesCarrera { get; set; }
        public string Alias { get; set; }
    }
}
