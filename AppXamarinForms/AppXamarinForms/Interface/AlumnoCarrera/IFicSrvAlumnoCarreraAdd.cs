using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using  AppXamarinForms.Models;

namespace AppXamarinForms.Interface.AlumnoCarrera
{
    public interface IFicSrvAlumnoCarreraAdd
    {
        Task<string> InsertAlumnos(eva_alumnos_carreras eva_alumnos_carreras);        
    }
}
