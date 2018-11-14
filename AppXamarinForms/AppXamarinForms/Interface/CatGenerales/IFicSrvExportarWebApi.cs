using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppXamarinForms.Interface.CatGenerales
{
   public interface IFicSrvExportarWebApi
    {
        Task<string> FicPostExportEdificios();
    }
}
