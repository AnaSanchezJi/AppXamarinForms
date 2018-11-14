using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppXamarinForms.Models;

namespace AppXamarinForms.Interface.CatGenerales
{
    public interface IFicSrvCatEdificiosUpdate
    {
        Task<string> Update_eva_cat_edificios(eva_cat_edificios eva_cat_edificios);
    }
}
