using AppXamarinForms.Interface.CatGenerales;
using AppXamarinForms.Data;
using AppXamarinForms.Interface.SQLite;
using AppXamarinForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppXamarinForms.Services.CatGenerales
{
   
    public class FicSrvImpExpWebApi : IFicSrvImpExpWebApi
    {

        private readonly FicDBContext FicLoBDContext;
        private readonly HttpClient FiClient;

        public FicSrvImpExpWebApi()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            FiClient = new HttpClient();
            FiClient.MaxResponseContentBufferSize = 256000;
        }
    
        public async Task<string> FicImportEdificios()
        {
            try
            {
                var GetRes = await FicGetEdificiosActualiza();

                if (GetRes != null)
                {
                    foreach (eva_cat_edificios edificio in GetRes)
                    {
                        System.Diagnostics.Debug.WriteLine("Edificio\n" + edificio.Alias);
                        var existe = await FicExisteEdificio(edificio);
                        if (existe != null)
                        {
                            try
                            {
                                FicLoBDContext.Update(edificio);
                                FicLoBDContext.Entry(edificio).State = EntityState.Detached;
                                await FicLoBDContext.SaveChangesAsync();
                            }
                            catch (Exception e)
                            {
                                System.Diagnostics.Debug.WriteLine("Exception\n" + e.Message.ToString());
                                return e.Message.ToString();
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(edificio);
                                FicLoBDContext.Entry(edificio).State = EntityState.Detached;
                                await FicLoBDContext.SaveChangesAsync();
                            }
                            catch (Exception e)
                            {
                                System.Diagnostics.Debug.WriteLine("ExceptionI\n" + e.Message.ToString());
                                return e.Message.ToString();
                            }
                        }

                    }
                    return "OK";
                }
                else
                {
                    return "NO HAY DATOS";
                }
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        private async Task<eva_cat_edificios> FicExisteEdificio(eva_cat_edificios edificio)
        {
            return await (from inv in FicLoBDContext.eva_cat_edificios where inv.IdEdificio == edificio.IdEdificio select inv).AsNoTracking().SingleOrDefaultAsync();
        }

        private async Task<List<eva_cat_edificios>> FicGetEdificiosActualiza()
        {
            string url = "http://localhost:51049/api/GetEdificios/";
            var response = await FiClient.GetAsync(url);
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<eva_cat_edificios>>(await response.Content.ReadAsStringAsync()) : null;
        }
       

        public async Task<string> FicExportEdificios()
        {
            try
            {
                List<eva_cat_edificios> list = await(from inv in FicLoBDContext.eva_cat_edificios select inv).AsNoTracking().ToListAsync();
                return await FicLoBDContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL REGISTRAR";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
