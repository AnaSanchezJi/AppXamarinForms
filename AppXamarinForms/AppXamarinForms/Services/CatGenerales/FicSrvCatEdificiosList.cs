using System;
using System.Collections.Generic;
using System.Text;
using AppXamarinForms.Interface.CatGenerales;
using AppXamarinForms.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AppXamarinForms.Interface.SQLite;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppXamarinForms.Models;


namespace AppXamarinForms.Services.CatGenerales
{
    public class FicSrvCatEdificiosList : IFicSvrCatEdificiosList
    {
        private readonly FicDBContext FicLoBDContext;
        public FicSrvCatEdificiosList()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }

        public async Task<IEnumerable<eva_cat_edificios>>FicMetGetListEdificios()
        {
            return await (from ed in FicLoBDContext.eva_cat_edificios select ed).AsNoTracking().ToListAsync();
        }
        
        public async Task<string> Remove_eva_cat_edificios(eva_cat_edificios eva_cat_edificios)
        {
            FicLoBDContext.Remove(eva_cat_edificios);
            return await FicLoBDContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL ELIMINAR";
        }
    }
}
