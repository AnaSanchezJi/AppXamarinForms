﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using AppXamarinForms.Droid.SQLite;
using AppXamarinForms.Interface.SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(FicConfigSQLiteDROID))]
namespace AppXamarinForms.Droid.SQLite
{
    class FicConfigSQLiteDROID : IFicConfigSQLite
    {
        public string FicGetDataBasePath()
        {
            var FicPathFile = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
            var FicDirectorioDB = FicPathFile.Path;
            FicDirectorioDB = FicDirectorioDB + "/CocacolaNay/";
            string FicPathDB = Path.Combine(FicDirectorioDB, FicAppSettings.FicDataBaseName);
            return FicPathDB;
        }
    }
}