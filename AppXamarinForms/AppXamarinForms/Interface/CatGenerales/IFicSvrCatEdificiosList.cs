using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using  AppXamarinForms.Models;


namespace AppXamarinForms.Interface.CatGenerales
{
    public interface IFicSvrCatEdificiosList
    {
        Task<IEnumerable<eva_cat_edificios>> FicMetGetListEdificios();
        Task<string> Remove_eva_cat_edificios(eva_cat_edificios eva_cat_edificios);
    }
}
