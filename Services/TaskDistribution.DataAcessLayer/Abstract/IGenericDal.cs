using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskDistribution.DataAcessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<List<T>> GetListWithFilter(Expression<Func<T, bool>> filter);
        Task<bool> SearchFilter(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllWithIncludes(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdWithIncludes(int id, params Expression<Func<T, object>>[] includes);


    }
}
