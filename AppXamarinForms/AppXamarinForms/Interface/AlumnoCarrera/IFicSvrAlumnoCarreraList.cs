using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using  AppXamarinForms.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AppXamarinForms.Interface.AlumnoCarrera
{
    public interface IFicSvrAlumnoCarreraList
    {
        Task<IEnumerable<eva_alumnos_carreras>> FicMetGetListAlumnos();
        Task<string> RemoveAlumnos(eva_alumnos_carreras eva_alumnos_carreras);
        Task<eva_cat_carreras> FicMetGetListCarrera(int c);
        Task<eva_cat_reticulas> FicMetGetListReticula(int re);
        Task<eva_cat_especialidades> FicMetGetListEspecialidad(int es);
        Task<cat_periodos> FicMetGetListPeriodo1(int p1);
        Task<cat_periodos> FicMetGetListPeriodo2(int p2);
        Task<cat_periodos> FicMetGetListPeriodo3(int p3);
        Task<cat_generales> FicMetGetListGen1(int g1);
        Task<cat_generales> FicMetGetListGen2(int g2);
        Task<cat_generales> FicMetGetListGen3(int g3);
        Task<cat_generales> FicMetGetListGen4(int g4);
        Task<rh_cat_personas> FicMetGetListAlumno(int a);
    }
}
