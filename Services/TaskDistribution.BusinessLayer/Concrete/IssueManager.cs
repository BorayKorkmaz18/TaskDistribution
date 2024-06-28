using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskDistribution.BusinessLayer.Abstract;
using TaskDistribution.DataAcessLayer.Abstract;
using TaskDistribution.DataAcessLayer.EntityFramework;
using TaskDistribution.EntityLayer.Concrete;

namespace TaskDistribution.BusinessLayer.Concrete
{
    public class IssueManager : IIssueService
    {

        private readonly IIssueDal _issueDal;

        public IssueManager(IIssueDal issueDal)
        {
            _issueDal = issueDal;
        }

        public async Task<List<Issue>> TGetAllWithIncludes(params Expression<Func<Issue, object>>[] includes)
        {
            return await _issueDal.GetAllWithIncludes(includes);
        }

        public async Task<List<Issue>> TGetListWithFilter(Expression<Func<Issue, bool>> filter)
        {
            return await _issueDal.GetListWithFilter(filter);
        }

        public async Task<bool> TSearchFilter(Expression<Func<Issue, bool>> filter)
        {
            return await _issueDal.SearchFilter(filter);
        }

        public async Task TDelete(int id)
        {
            await _issueDal.Delete(id);
        }

        public async Task<List<Issue>> TGetAll()
        {
            return await _issueDal.GetAll();
        }

        public Task<Issue> TGetById(int id)
        {
            return _issueDal.GetById(id);
        }

        public async Task TInsert(Issue entity)
        {
            await _issueDal.Insert(entity);
        }

        public async Task TUpdate(Issue entity)
        {
            await _issueDal.Update(entity);
        }
        public async Task<Issue> TGetByIdWithIncludes(int id, params Expression<Func<Issue, object>>[] includes)
        {
            return await _issueDal.GetByIdWithIncludes(id, includes);
        }
    }
}
