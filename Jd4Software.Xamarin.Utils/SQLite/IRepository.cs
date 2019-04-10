using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jd4Software.Utils.SQLite
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> Find(int id);
        Task<List<T>> GetAll();
        Task<int> Insert(T entity);
        Task InsertAll(IEnumerable<T> entities);
        Task<int> Delete(T entity);
        Task Update(T entity);
        void CreateTable();
        Task Drop();
        Task DeleteAll();
        Task<int> GetRecordCount();
    }
}
