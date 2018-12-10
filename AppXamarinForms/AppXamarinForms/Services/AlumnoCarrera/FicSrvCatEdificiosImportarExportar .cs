using AppXamarinForms.Data;
using AppXamarinForms.Interface.AlumnoCarrera;
using AppXamarinForms.Interface.SQLite;
using AppXamarinForms.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;


namespace AppXamarinForms.Services.AlumnoCarrera
{
    public class FicSrvCatEdificiosImportarExportar : IFicSrvCatEdificiosImportarExportar
    {

        private readonly FicDBContext DBLoContext;
        private readonly HttpClient Client;

        public FicSrvCatEdificiosImportarExportar()
        {
            DBLoContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
            Client = new HttpClient();
            Client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<string> Importar_eva_cat_edificios()
        {
            try
            {

                var GetRes = await GetCatEdificiosAPI();

                if (GetRes != null)
                {
                    foreach (eva_alumnos_carreras edificio in GetRes)
                    {
                        System.Diagnostics.Debug.WriteLine("Edificio\n" + edificio.IdAlumno);
                        var existe = await ExisteEdificio(edificio);
                        if (existe != null)
                        {
                            try
                            {

                                DBLoContext.Entry(existe).State = EntityState.Detached;
                                DBLoContext.Entry(edificio).State = EntityState.Modified;
                                await DBLoContext.SaveChangesAsync();
                                DBLoContext.Entry(edificio).State = EntityState.Detached;
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
                                DBLoContext.Add(edificio);
                                await DBLoContext.SaveChangesAsync();
                                DBLoContext.Entry(edificio).State = EntityState.Detached;
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

        private async Task<eva_alumnos_carreras> ExisteEdificio(eva_alumnos_carreras edificio)
        {
            return await (from inv in DBLoContext.eva_alumnos_carreras where inv.IdAlumno == edificio.IdAlumno select inv).AsNoTracking().SingleOrDefaultAsync();
        }

        private async Task<List<eva_alumnos_carreras>> GetCatEdificiosAPI()
        {
            string url = "http://localhost:53213/api/Edificios";
            var res = await Client.GetAsync(url);
            return res.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<eva_alumnos_carreras>>(await res.Content.ReadAsStringAsync()) : null;
        }

        public async Task<string> Exportar_eva_cat_edificios()
        {
            try
            {
                List<eva_alumnos_carreras> list = await (from CE in DBLoContext.eva_alumnos_carreras select CE).AsNoTracking().ToListAsync();
                return await PutCatEdificiosAPI(list);
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }

        }

        private async Task<string> PutCatEdificiosAPI(List<eva_alumnos_carreras> list)
        {
            string url = "http://localhost:53213/api/ExpAlumnoCarrera";
            HttpResponseMessage res = await Client.PutAsync(new Uri(string.Format(url, string.Empty)),
                new StringContent(JsonConvert.SerializeObject(list), Encoding.UTF8, "application/json"));
            return res.IsSuccessStatusCode ? "OK" : "ERROR";
        }

    }
}
