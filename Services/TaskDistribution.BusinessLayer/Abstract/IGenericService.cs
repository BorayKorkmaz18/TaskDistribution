using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskDistribution.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TInsert(T entity);
        Task TUpdate(T entity);
        Task TDelete(int id);
        Task<T> TGetById(int id);
        Task<List<T>> TGetAll();
        Task<List<T>> TGetListWithFilter(Expression<Func<T, bool>> filter);
        Task<bool> TSearchFilter(Expression<Func<T, bool>> filter);
        Task<List<T>> TGetAllWithIncludes(params Expression<Func<T, object>>[] includes);
        Task<T> TGetByIdWithIncludes(int id, params Expression<Func<T, object>>[] includes);


    }
}
