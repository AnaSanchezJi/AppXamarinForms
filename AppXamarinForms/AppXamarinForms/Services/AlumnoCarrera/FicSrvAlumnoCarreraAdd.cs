using AppXamarinForms.Data;
using AppXamarinForms.Interface.AlumnoCarrera;
using AppXamarinForms.Interface.SQLite;
using AppXamarinForms.Models;
using AppXamarinForms.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXamarinForms.Services.AlumnoCarrera
{
    public class FicSrvAlumnoCarreraAdd : IFicSrvAlumnoCarreraAdd
    {
        private readonly FicDBContext FicDBLoContext;
        public FicSrvAlumnoCarreraAdd()
        {
            FicDBLoContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }

        

        public async Task<string> InsertAlumnos(eva_alumnos_carreras eva_alumnos_carreras)
        {
            try
            {
                await FicDBLoContext.AddAsync(eva_alumnos_carreras);
                var res = await FicDBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL REGISTRAR";
                FicDBLoContext.Entry(eva_alumnos_carreras).State = EntityState.Detached;
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
