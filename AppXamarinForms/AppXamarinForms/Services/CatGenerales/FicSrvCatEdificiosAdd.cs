using AppXamarinForms.Data;
using AppXamarinForms.Interface.CatGenerales;
using AppXamarinForms.Interface.SQLite;
using AppXamarinForms.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXamarinForms.Services.CatGenerales
{
    public class FicSrvCatEdificiosAdd : IFicSrvCatEdificiosAdd
    {
        private readonly FicDBContext FicDBLoContext;
        public FicSrvCatEdificiosAdd()
        {
            FicDBLoContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }


        public async Task<string> Insert_eva_cat_edificios(eva_cat_edificios eva_cat_edificios)
        {
            try
            {
                await FicDBLoContext.AddAsync(eva_cat_edificios);
                return await FicDBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL REGISTRAR";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
