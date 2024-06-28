using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskDistribution.BusinessLayer.Abstract;
using TaskDistribution.DataAcessLayer.Abstract;
using TaskDistribution.EntityLayer.Concrete;

namespace TaskDistribution.BusinessLayer.Concrete
{
    public class RoleManager : IRoleService
    {

        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public async Task<List<Role>> TGetAllWithIncludes(params Expression<Func<Role, object>>[] includes)
        {
            return await _roleDal.GetAllWithIncludes(includes);
        }

        public async Task<List<Role>> TGetListWithFilter(Expression<Func<Role, bool>> filter)
        {
            return await _roleDal.GetListWithFilter(filter);
        }

        public async Task<bool> TSearchFilter(Expression<Func<Role, bool>> filter)
        {
            return await _roleDal.SearchFilter(filter);
        }

        public async Task TDelete(int id)
        {
            await _roleDal.Delete(id);
        }

        public async Task<List<Role>> TGetAll()
        {
            return await _roleDal.GetAll();
        }

        public Task<Role> TGetById(int id)
        {
            return _roleDal.GetById(id);
        }

        public async Task TInsert(Role entity)
        {
            await _roleDal.Insert(entity);
        }

        public async Task TUpdate(Role entity)
        {
            await _roleDal.Update(entity);
        }

        public async Task<Role> TGetByIdWithIncludes(int id, params Expression<Func<Role, object>>[] includes)
        {
            return await _roleDal.GetByIdWithIncludes(id, includes);
        }
    }
}
