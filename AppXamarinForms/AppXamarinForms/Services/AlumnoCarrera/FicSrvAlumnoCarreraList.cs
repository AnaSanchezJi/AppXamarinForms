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

        public async Task<rh_cat_personas> FicMetGetListAlumno(int a)
        {
            List<rh_cat_personas> aux = await(from asignatura in FicLoBDContext.rh_cat_personas select asignatura).Where((asignatura) => asignatura.IdPersona == a).AsNoTracking().ToListAsync();
            rh_cat_personas asignaturaItem = new rh_cat_personas();
            aux.ForEach(item => {
                asignaturaItem = item;
            });
            return asignaturaItem;
        }

        public async Task<IEnumerable<eva_alumnos_carreras>> FicMetGetListAlumnos()
        {
            return await (from ed in FicLoBDContext.eva_alumnos_carreras select ed).AsNoTracking().ToListAsync();
        }

        

        public async Task<eva_cat_carreras> FicMetGetListCarrera(int c)
        {
            List<eva_cat_carreras> aux = await(from asignatura in FicLoBDContext.eva_cat_carreras select asignatura).Where((asignatura) => asignatura.IdCarrera == c).AsNoTracking().ToListAsync();
            eva_cat_carreras asignaturaItem = new eva_cat_carreras();
            aux.ForEach(item => {
                asignaturaItem = item;
            });
            return asignaturaItem;
        }

        public async Task<eva_cat_especialidades> FicMetGetListEspecialidad(int es)
        {
            List<eva_cat_especialidades> aux = await(from asignatura in FicLoBDContext.eva_cat_especialidades select asignatura).Where((asignatura) => asignatura.IdEspecialidad == es).AsNoTracking().ToListAsync();
            eva_cat_especialidades asignaturaItem = new eva_cat_especialidades();
            aux.ForEach(item => {
                asignaturaItem = item;
            });
            return asignaturaItem;
        }

        public async Task<cat_generales> FicMetGetListGen1(int g1)
        {
            List<cat_generales> aux = await (from asignatura in FicLoBDContext.cat_generales select asignatura).Where((asignatura) => asignatura.IdTipoGeneral == 27).AsNoTracking().ToListAsync();
            cat_generales asignaturaItem = new cat_generales();
            aux.ForEach(item => {
                asignaturaItem = item;
            });
            return asignaturaItem;
        }

        public async Task<cat_generales> FicMetGetListGen2(int g2)
        {
            List<cat_generales> aux = await (from asignatura in FicLoBDContext.cat_generales select asignatura).Where((asignatura) => asignatura.IdTipoGeneral == 17).AsNoTracking().ToListAsync();
            cat_generales asignaturaItem = new cat_generales();
            aux.ForEach(item => {
                asignaturaItem = item;
            });
            return asignaturaItem;
        }

        public async Task<cat_generales> FicMetGetListGen3(int g3)
        {
            List<cat_generales> aux = await(from asignatura in FicLoBDContext.cat_generales select asignatura).Where((asignatura) => asignatura.IdTipoGeneral == 27).AsNoTracking().ToListAsync();
            cat_generales asignaturaItem = new cat_generales();
            aux.ForEach(item => {
                asignaturaItem = item;
            });
            return asignaturaItem;
        }

        public async Task<cat_generales> FicMetGetListGen4(int g4)
        {
            List<cat_generales> aux = await(from asignatura in FicLoBDContext.cat_generales select asignatura).Where((asignatura) => asignatura.IdTipoGeneral == 28).AsNoTracking().ToListAsync();
            cat_generales asignaturaItem = new cat_generales();
            aux.ForEach(item => {
                asignaturaItem = item;
            });
            return asignaturaItem;
        }

        public async  Task<cat_periodos> FicMetGetListPeriodo1(int p1)
        {
            List<cat_periodos> aux = await(from asignatura in FicLoBDContext.cat_periodos select asignatura).Where((asignatura) => asignatura.IdPeriodo == p1).AsNoTracking().ToListAsync();
            cat_periodos asignaturaItem = new cat_periodos();
            aux.ForEach(item => {
                asignaturaItem = item;
            });
            return asignaturaItem;
        }

        public async Task<cat_periodos> FicMetGetListPeriodo2(int p2)
        {
            List<cat_periodos> aux = await(from asignatura in FicLoBDContext.cat_periodos select asignatura).Where((asignatura) => asignatura.IdPeriodo == p2).AsNoTracking().ToListAsync();
            cat_periodos asignaturaItem = new cat_periodos();
            aux.ForEach(item => {
                asignaturaItem = item;
            });
            return asignaturaItem;
        }

        public async Task<cat_periodos> FicMetGetListPeriodo3(int p3)
        {
            List<cat_periodos> aux = await(from asignatura in FicLoBDContext.cat_periodos select asignatura).Where((asignatura) => asignatura.IdPeriodo == p3).AsNoTracking().ToListAsync();
            cat_periodos asignaturaItem = new cat_periodos();
            aux.ForEach(item => {
                asignaturaItem = item;
            });
            return asignaturaItem;
        }

        public async Task<eva_cat_reticulas> FicMetGetListReticula(int re)
        {
            List<eva_cat_reticulas> aux = await(from asignatura in FicLoBDContext.eva_cat_reticulas select asignatura).Where((asignatura) => asignatura.IdReticula == re).AsNoTracking().ToListAsync();
            eva_cat_reticulas asignaturaItem = new eva_cat_reticulas();
            aux.ForEach(item => {
                asignaturaItem = item;
            });
            return asignaturaItem;
        }

        public async Task<string> RemoveAlumnos(eva_alumnos_carreras eva_alumnos_carreras)
        {
            FicLoBDContext.Remove(eva_alumnos_carreras);
            return await FicLoBDContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ELIMINAR";
        }

        Task<rh_cat_personas> IFicSvrAlumnoCarreraList.FicMetGetListDetalleAlumnos(int c)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<rh_cat_personas>> FicMetGetListDetalleAlumnos(int c)
        {
            return await (from ed in FicLoBDContext.rh_cat_personas where ed.IdPersona == c select ed).AsNoTracking().ToListAsync();
        }
    }
}
