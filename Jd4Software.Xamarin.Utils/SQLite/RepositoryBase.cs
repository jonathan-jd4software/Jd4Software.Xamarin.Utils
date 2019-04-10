using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jd4Software.Utils.SQLite
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity, new()
    {
        private readonly IDatabaseConnectionManager _dbConnectionManager;

        public RepositoryBase(IDatabaseConnectionManager dbConnectionManager)
        {
            _dbConnectionManager = dbConnectionManager;
        }

        public void CreateTable()
        {
            _dbConnectionManager.Connection.CreateTableAsync<T>().Wait();
        }

        public Task<int> Insert(T entity)
        {
            return _dbConnectionManager.Connection.InsertAsync(entity);
        }


        public Task InsertAll(IEnumerable<T> entities)
        {
            return _dbConnectionManager.Connection.InsertAllAsync(entities);
        }


        public Task<T> Find(int id)
        {
            return _dbConnectionManager.Connection.FindAsync<T>(id);
        }


        public Task<List<T>> GetAll()
        {
            return _dbConnectionManager.Connection.Table<T>().ToListAsync();
        }

        public Task Drop()
        {
            return _dbConnectionManager.Connection.DropTableAsync<T>();
        }

        public Task<int> Delete(T entity)
        {
            return _dbConnectionManager.Connection.DeleteAsync(entity);
        }


        public Task DeleteAll()
        {
            return _dbConnectionManager.Connection.ExecuteScalarAsync<T>(string.Format("Delete from {0}", typeof(T).Name));
        }

        public Task Update(T entity)
        {
            return _dbConnectionManager.Connection.UpdateAsync(entity);
        }


        public Task<int> GetRecordCount()
        {
            return _dbConnectionManager.Connection.Table<T>().CountAsync();
        }
    }
}
