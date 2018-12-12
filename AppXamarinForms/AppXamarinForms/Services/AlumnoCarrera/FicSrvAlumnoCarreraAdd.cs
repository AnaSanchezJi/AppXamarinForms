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

        public async  Task<IEnumerable<rh_cat_personas>> FicMetGetListAlumno()
        {
            return await(from carrera in FicDBLoContext.rh_cat_personas select carrera).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_cat_carreras>> FicMetGetListCarrera()
        {
            return await(from carrera in FicDBLoContext.eva_cat_carreras select carrera).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_cat_especialidades>> FicMetGetListEspecialidad()
        {
            return await(from carrera in FicDBLoContext.eva_cat_especialidades select carrera).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<cat_generales>> FicMetGetListGen1()
        {
            return await(from carrera in FicDBLoContext.cat_generales select carrera).Where((carrera) => carrera.IdTipoGeneral == 25).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<cat_generales>> FicMetGetListGen2()
        {
            return await(from carrera in FicDBLoContext.cat_generales select carrera).Where((carrera) => carrera.IdTipoGeneral == 27).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<cat_generales>> FicMetGetListGen3()
        {
            return await(from carrera in FicDBLoContext.cat_generales select carrera).Where((carrera) => carrera.IdTipoGeneral == 17).AsNoTracking().ToListAsync();
        }

        public  async Task<IEnumerable<cat_generales>> FicMetGetListGen4()
        {
            return await(from carrera in FicDBLoContext.cat_generales select carrera).AsNoTracking().Where((carrera) => carrera.IdTipoGeneral == 28).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<cat_periodos>> FicMetGetListPeriodo1()
        {
            return await (from carrera in FicDBLoContext.cat_periodos select carrera).AsNoTracking().ToListAsync();
        }
      
        public async Task<IEnumerable<cat_periodos>> FicMetGetListPeriodo2()
        {
            return await(from carrera in FicDBLoContext.cat_periodos select carrera).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<cat_periodos>> FicMetGetListPeriodo3()
        {
            return await(from carrera in FicDBLoContext.cat_periodos select carrera).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<eva_cat_reticulas>> FicMetGetListReticula()
        {
            return await (from reticula in FicDBLoContext.eva_cat_reticulas select reticula).AsNoTracking().ToListAsync();
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
