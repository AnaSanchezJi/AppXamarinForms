using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppXamarinForms.Models;

namespace AppXamarinForms.Interface.AlumnoCarrera
{
    public interface IFicSrvAlumnoCarreraUpdate
    {
        Task<string> UpdateAlumno(eva_alumnos_carreras eva_alumnos_carreras);
        Task<IEnumerable<eva_cat_carreras>> FicMetGetListCarrera();
        Task<IEnumerable<eva_cat_reticulas>> FicMetGetListReticula();
        Task<IEnumerable<eva_cat_especialidades>> FicMetGetListEspecialidad();
        Task<IEnumerable<cat_periodos>> FicMetGetListPeriodo1();
        Task<IEnumerable<cat_periodos>> FicMetGetListPeriodo2();
        Task<IEnumerable<cat_periodos>> FicMetGetListPeriodo3();
        Task<IEnumerable<cat_generales>> FicMetGetListGen1();
        Task<IEnumerable<cat_generales>> FicMetGetListGen2();
        Task<IEnumerable<cat_generales>> FicMetGetListGen3();
        Task<IEnumerable<cat_generales>> FicMetGetListGen4();
        Task<IEnumerable<rh_cat_personas>> FicMetGetListAlumno();
    }
}
