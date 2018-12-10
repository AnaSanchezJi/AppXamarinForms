using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppXamarinForms.UWP.SQLite;
using AppXamarinForms.Interface.SQLite;
using Xamarin.Forms;
using Windows.Storage;
using System.IO;

[assembly: Dependency(typeof(FicConfigSQLiteUWP))]
namespace AppXamarinForms.UWP.SQLite
{
    class FicConfigSQLiteUWP : IFicConfigSQLite
    {
        public string FicGetDataBasePath()
        {
            
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, FicAppSettings.FicDataBaseName);
        }
    }
}
