using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using  AppXamarinForms.Models;


namespace AppXamarinForms.Interface.AlumnoCarrera
{
    public interface IFicSvrAlumnoCarreraList
    {
        Task<IEnumerable<eva_alumnos_carreras>> FicMetGetListAlumnos();
        Task<string> RemoveAlumnos(eva_alumnos_carreras eva_alumnos_carreras);
    }
}
