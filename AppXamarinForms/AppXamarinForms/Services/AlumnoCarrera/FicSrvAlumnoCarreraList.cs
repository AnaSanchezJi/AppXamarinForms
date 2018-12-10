using System;
using System.Collections.Generic;
using System.Text;
using AppXamarinForms.Interface.AlumnoCarrera;
using AppXamarinForms.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AppXamarinForms.Interface.SQLite;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppXamarinForms.Models;

namespace AppXamarinForms.Services.AlumnoCarrera
{
    public class FicSrvAlumnoCarreraList : IFicSvrAlumnoCarreraList
    {
        private readonly FicDBContext FicLoBDContext;
        public FicSrvAlumnoCarreraList()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }

        public async Task<IEnumerable<eva_alumnos_carreras>> FicMetGetListAlumnos()
        {
            return await (from ed in FicLoBDContext.eva_alumnos_carreras select ed).AsNoTracking().ToListAsync();
        }
        
        public async Task<string> RemoveAlumnos(eva_alumnos_carreras eva_alumnos_carreras)
        {
            FicLoBDContext.Remove(eva_alumnos_carreras);
            return await FicLoBDContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ELIMINAR";
        }
    }
}
