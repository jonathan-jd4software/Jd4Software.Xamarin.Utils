using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jd4Software.Utils.SQLite
{
    public class DatabaseConnectionManager : IDatabaseConnectionManager
    {
        private SQLiteAsyncConnection _connection;

        public string DatabasePath { get; set; }

        public DatabaseConnectionManager(string path, string dbName)
        {
            DatabasePath = Path.Combine(path, dbName);
            try
            {
                _connection = new SQLiteAsyncConnection(DatabasePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Utils.Library.Data.DatabaseConnectionManager:" + ex.Message);
            }
        }


        public SQLiteAsyncConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    if (!string.IsNullOrEmpty(DatabasePath))
                    {
                        _connection = new SQLiteAsyncConnection(DatabasePath);
                    }
                    return null;
                }
                return _connection;
            }
        }
    }
}
