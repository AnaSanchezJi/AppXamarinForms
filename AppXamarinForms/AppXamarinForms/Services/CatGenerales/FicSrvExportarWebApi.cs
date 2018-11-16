using System;
using System.Collections.Generic;
using System.Text;
using AppXamarinForms.Data;
using AppXamarinForms.Interface.CatGenerales;
using AppXamarinForms.Interface.SQLite;
using AppXamarinForms.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace AppXamarinForms.Services.CatGenerales
{
    public class FicSrvExportarWebApi : IFicSrvExportarWebApi
    {
        private readonly FicDBContext FicLoDBContext;
        private readonly HttpClient FiClient;

        public FicSrvExportarWebApi()
        {
            FicLoDBContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            FiClient = new HttpClient();
            FiClient.MaxResponseContentBufferSize = 256000;

        }
       private async Task<string> FicPostListInventarios(List<eva_cat_edificios> ed)
        {
                const string url = "http://localhost:51049/api/ExpEdificios";
                HttpResponseMessage response = await FiClient.PostAsync(
                    new Uri(string.Format(url, string.Empty)),
                    new StringContent(JsonConvert.SerializeObject(ed), Encoding.UTF8, "application/json"));
                return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> FicPostExportEdificios()
        {
            return await FicPostListInventarios(
                await (from edi in FicLoDBContext.eva_cat_edificios select edi).AsNoTracking().ToListAsync());
            
        }

        
    }
}
