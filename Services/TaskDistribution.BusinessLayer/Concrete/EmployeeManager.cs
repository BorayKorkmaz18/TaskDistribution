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
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public async Task<List<Employee>> TGetAllWithIncludes(params Expression<Func<Employee, object>>[] includes)
        {
            return await _employeeDal.GetAllWithIncludes(includes);
        }

        public async Task<List<Employee>> TGetListWithFilter(Expression<Func<Employee, bool>> filter)
        {
            return await _employeeDal.GetListWithFilter(filter);
        }

        public async Task<bool> TSearchFilter(Expression<Func<Employee, bool>> filter)
        {
            return await _employeeDal.SearchFilter(filter);
        }

        public async Task TDelete(int id)
        {
            await _employeeDal.Delete(id);
        }

        public async Task<List<Employee>> TGetAll()
        {
            return await _employeeDal.GetAll();
        }

        public Task<Employee> TGetById(int id)
        {
            return _employeeDal.GetById(id);
        }

        public Task TInsert(Employee entity)
        {
            return _employeeDal.Insert(entity);
        }

        public Task TUpdate(Employee entity)
        {
            return _employeeDal.Update(entity);
        }

        public Task<Employee> TGetByIdWithIncludes(int id, params Expression<Func<Employee, object>>[] includes)
        {
            return _employeeDal.GetByIdWithIncludes(id, includes);
        }
    }
}
