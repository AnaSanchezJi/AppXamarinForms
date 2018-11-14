using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using AppXamarinForms.iOS.SQLite;
using AppXamarinForms.Interface.SQLite;
using Xamarin.Forms;
using System.IO;


[assembly: Dependency(typeof(FicConfigSQLiteOS))]
namespace AppXamarinForms.iOS.SQLite
{
    class FicConfigSQLiteOS : IFicConfigSQLite
    {
        public string FicGetDataBasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, FicAppSettings.FicDataBaseName);
        }
    }
}