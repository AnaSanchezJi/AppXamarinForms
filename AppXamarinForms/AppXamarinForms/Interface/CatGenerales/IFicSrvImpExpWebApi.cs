using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppXamarinForms.Interface.CatGenerales
{
    public interface IFicSrvImpExpWebApi
    {
        Task<string> FicExportEdificios();
        Task<string> FicImportEdificios();
    }
}
