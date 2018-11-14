using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using  AppXamarinForms.Models;

namespace AppXamarinForms.Interface.CatGenerales
{
    public interface IFicSrvCatEdificiosAdd
    {
        Task<string> Insert_eva_cat_edificios(eva_cat_edificios eva_cat_edificios);
    }
}
