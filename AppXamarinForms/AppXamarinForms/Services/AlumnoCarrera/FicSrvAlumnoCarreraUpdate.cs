using AppXamarinForms.Data;
using AppXamarinForms.Interface.AlumnoCarrera;
using AppXamarinForms.Interface.SQLite;
using AppXamarinForms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace AppXamarinForms.Services.AlumnoCarrera
{
    public class FicSrvAlumnoCarreraUpdate : IFicSrvAlumnoCarreraUpdate
    {

        private readonly FicDBContext FicDBLoContext;

        public FicSrvAlumnoCarreraUpdate()
        {
            FicDBLoContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }
        public async Task<string> UpdateAlumno(eva_alumnos_carreras eva_alumnos_carreras)
        {
            try {
                FicDBLoContext.Update(eva_alumnos_carreras);
                var res = await FicDBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL REGISTRAR";
                FicDBLoContext.Entry(eva_alumnos_carreras).State = EntityState.Detached;
                return res;
            }
            catch (Exception err)
            {
                return err.Message.ToString();
            }
        }
    }
}
