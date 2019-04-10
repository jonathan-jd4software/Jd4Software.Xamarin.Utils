using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jd4Software.Utils.SQLite
{
    public interface IDatabaseConnectionManager
    {
        string DatabasePath { get; set; }
        SQLiteAsyncConnection Connection { get; }
    }
}
