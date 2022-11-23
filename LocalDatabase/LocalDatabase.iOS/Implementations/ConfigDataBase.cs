using System.IO;
using Xamarin.Forms;
using LocalDatabase.Interfaces;
using LocalDatabase.iOS.Implementations;
using System;

[assembly: Dependency(typeof(ConfigDataBase))]
namespace LocalDatabase.iOS.Implementations
{
    public class ConfigDataBase : IConfigDataBase
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseFileName);
        }
    }
}

