using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IRepository <T> where T : class
    { 
       public Task<T> GetById(int id);
       public Task<IEnumerable<T>> GetAll();
       public Task<T> Add(T entity);
       public Task<T> Update(T entity);
       public Task<T> Delete(T entity);
    }
}
