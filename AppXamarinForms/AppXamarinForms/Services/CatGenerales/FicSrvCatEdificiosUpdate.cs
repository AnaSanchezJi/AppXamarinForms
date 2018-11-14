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
    public class FicSrvCatEdificiosUpdate : IFicSrvCatEdificiosUpdate
    {

        private readonly FicDBContext FicDBLoContext;

        public FicSrvCatEdificiosUpdate()
        {
            FicDBLoContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }
        public async Task<string> Update_eva_cat_edificios(eva_cat_edificios eva_cat_edificios)
        {
            try { 
            FicDBLoContext.Update(eva_cat_edificios);
            return await FicDBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL REGISTRAR";
            }
            catch (Exception err)
            {
                return err.Message.ToString();
            }
        }
    }
}
