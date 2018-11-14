using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppXamarinForms.Interface.CatGenerales
{
    public interface IFicSrvImportarWebApi
    {
        Task<string> FicGetImportEdificios();
    }
}
