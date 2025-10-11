using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IRepository <T> where T : class
    { 
       public T GetById(int id);
       public IEnumerable<T> GetAll();
       public T Add(T entity);
       public T Update(T entity);
       public T Delete(T entity);
    }
}
