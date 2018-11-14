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
        [Table("cat_tipos_estatus")]
        public class cat_tipos_estatus
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdTipoEstatus { get; set; }
            [MaxLength(30)]
            public string DesTipoEstatus { get; set; }
            [MaxLength(1)]
            public string Activo { get; set; }
            public DateTime FechaReg { get; set; }
            [MaxLength(20)]
            public string UsuarioReg { get; set; }
            public DateTime FechaUltMod { get; set; }
            [MaxLength(20)]
            public string UsuarioMod { get; set; }
            [MaxLength(1)]
            public string Borrado { get; set; }
        }
        [Table("cat_estatus")]
        public class cat_estatus
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdTipoEstatus { get; set; }
            public Int16 IdEstatus { get; set; }
            [MaxLength(50)]
            public string Clave { get; set; }
            [MaxLength(30)]
            public string DesEstatus { get; set; }
            [MaxLength(1)]
            public string Activo { get; set; }
            public DateTime FechaReg { get; set; }
            public DateTime FechaUltMod { get; set; }
            [MaxLength(20)]
            public string UsuarioReg { get; set; }
            [MaxLength(20)]
            public string UsuarioMod { get; set; }
            [MaxLength(1)]
            public string Borrado { get; set; }
            public cat_tipos_estatus cat_tipo_estatus { get; set; }
        }
        [Table("eva_cat_edificios")]
        public class eva_cat_edificios
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdEdificio { get; set; }
            [MaxLength(10)]
            public string Alias { get; set; }
            [MaxLength(50)]
            public string DesEdificio { get; set; }
            public Int16 Prioridad { get; set; }
            [MaxLength(20)]
            public string Clave { get; set; }
            public DateTime FechaReg { get; set; }
            public DateTime FechaUltMod { get; set; }
            [MaxLength(20)]
            public string UsuarioReg { get; set; }
            [MaxLength(20)]
            public string UsuarioMod { get; set; }
            [MaxLength(1)]
            public string Activo { get; set; }
            [MaxLength(1)]
            public string Borrado { get; set; }


        }
        [Table("eva_cat_espacios")]
        public class eva_cat_espacios
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            //foranea

            public Int16 IdEdificio { get; set; }
            public eva_cat_edificios eva_cat_edificios { get; set; }
            public Int16 IdEspacio { get; set; }
            [MaxLength(20)]
            public string Clave { get; set; }
            [MaxLength(50)]
            public string DesEspacio { get; set; }
            public Int16 Prioridad { get; set; }
            [MaxLength(10)]
            public string Alias { get; set; }
            public Int16 RangoTiempoReserva { get; set; }
            public Int16 Capacidad { get; set; }
            // foreing key
            public Int16 IdTipoEstatus { get; set; }
            public cat_tipos_estatus cat_tipos_status { get; set; }
            //foreing key
            public Int16 IdEstatus { get; set; }
            public cat_estatus cat_status { get; set; }
            [MaxLength(255)]
            public string RefeUbicacion { get; set; }
            [MaxLength(1)]
            public string PermiteCruce { get; set; }
            [MaxLength(20)]
            public string Observacion { get; set; }
            public DateTime FechaReg { get; set; }
            public DateTime FechaUltMod { get; set; }
            [MaxLength(20)]
            public string UsuarioReg { get; set; }
            [MaxLength(20)]
            public string UsuarioMod { get; set; }
            [MaxLength(1)]
            public string Activo { get; set; }
            [MaxLength(1)]
            public string Borrado { get; set; }

        }

    public class eva_cat_list_edificios
    {
        public List<eva_cat_edificios> eva_cat_edificios { get; set; }

    }
}
