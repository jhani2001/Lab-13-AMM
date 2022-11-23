using System;
using System.Collections.Generic;
using System.Text;

namespace LocalDatabase.Interfaces
{
    public interface IConfigDataBase
    {
        string GetFullPath(string databaseFileName);
    }
}

