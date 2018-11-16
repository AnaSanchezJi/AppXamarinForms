using AppXamarinForms.Interface.CatGenerales;
using AppXamarinForms.Data;
using AppXamarinForms.Interface.SQLite;
using System;
using AppXamarinForms.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;
using System.Linq;
using System.Text;


namespace AppXamarinForms.Services.CatGenerales
{
    public class FicSrvImportarWebApi : IFicSrvImportarWebApi
    {
        private readonly FicDBContext FicLoBDContext;
        private readonly HttpClient FiClient;

        public FicSrvImportarWebApi()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            FiClient = new HttpClient();
            FiClient.MaxResponseContentBufferSize = 256000;
        }
        private async Task<List<eva_cat_edificios>> FicGetEdificiosActualiza()
        {
            string url = "http://localhost:51049/api/GetEdificios/";
            var response = await FiClient.GetAsync(url);
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<eva_cat_edificios>>(await response.Content.ReadAsStringAsync()) : null;
        }

        private async Task<eva_cat_edificios> FicExistecat_edificio(int edificio)
        {
            return await (from inv in FicLoBDContext.eva_cat_edificios where inv.IdEdificio == edificio select inv).AsNoTracking().SingleOrDefaultAsync();
        }


        public async Task<string> FicGetImportEdificios()
        {
            string FicMensaje = "";
            try
            {
            FicMensaje = "IMPORTACION: \n";
            var FicGetReultREST = await FicGetEdificiosActualiza();

                if (FicGetReultREST != null)
                {
                    FicMensaje += "IMPORTANDO: eva_cat_edificios \n";
                    foreach (eva_cat_edificios ed in FicGetReultREST)
                    {                        
                        var respuesta = await FicExistecat_edificio(ed.IdEdificio);
                        if (respuesta != null)
                        {
                            try
                            {
                                respuesta.IdEdificio = ed.IdEdificio;
                                respuesta.Alias = ed.Alias;
                                respuesta.DesEdificio = ed.DesEdificio;
                                respuesta.Prioridad = ed.Prioridad;
                                respuesta.Clave = ed.Clave;
                                respuesta.FechaReg = ed.FechaReg;
                                respuesta.FechaUltMod = ed.FechaUltMod;
                                respuesta.UsuarioMod = ed.UsuarioMod;
                                respuesta.UsuarioReg = ed.UsuarioReg;
                                respuesta.Activo = ed.Activo;
                                respuesta.Borrado = ed.Borrado;
                                FicLoBDContext.Entry(respuesta).State = EntityState.Modified;                                
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-UPDATE-> IdEdificio: " + ed.IdEdificio + " \n" : "-NO NECESITO ACTUALIZAR->  IdEdificio: " + ed.IdEdificio + " \n";
                                FicLoBDContext.Entry(ed).State = EntityState.Detached;
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> ... " + e.Message.ToString() + " \n";
                            }
                        }
                        else
                        {
                            try
                            {
                                FicLoBDContext.Add(ed);                                
                                FicMensaje += await FicLoBDContext.SaveChangesAsync() > 0 ? "-INSERT-> IdEdificio: " + ed.IdEdificio + " \n" : "-ERROR EN INSERT-> IdEdificio: " + ed.IdEdificio + " \n";
                                FicLoBDContext.Entry(ed).State = EntityState.Detached;
                            }
                            catch (Exception e)
                            {
                                FicMensaje += "-ALERTA-> .," + e.Message.ToString() + " \n";
                            }
                        }
                    }                    
                }
                else
                {
                    FicMensaje += "-> SIN DATOS. \n";
                }
            }
            catch (Exception e)
            {
                FicMensaje += "ALERTA: ,., " + e.Message.ToString() + "\n";
            }
            return FicMensaje;
        }
 
    }  
}
