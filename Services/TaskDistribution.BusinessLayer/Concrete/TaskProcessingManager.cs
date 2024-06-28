using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskDistribution.BusinessLayer.Abstract;
using TaskDistribution.BusinessLayer.Extensions;
using TaskDistribution.DataAcessLayer.Abstract;
using TaskDistribution.EntityLayer.Concrete;

namespace TaskDistribution.BusinessLayer.Concrete
{
    public class TaskProcessingManager : ITaskProcessingService
    {

        private readonly ITaskProcessingDal _taskProcessingDal;
        private readonly IEmployeeDal _employeeDal;
        private readonly IIssueDal _issueDal;
        public TaskProcessingManager(ITaskProcessingDal taskProcessingDal, IEmployeeDal employeeDal, IIssueDal issueDal)
        {
            _taskProcessingDal = taskProcessingDal;
            _employeeDal = employeeDal;
            _issueDal = issueDal;
        }

        public async Task<string> AssignTask(int id)
        {

            var developerList = await _employeeDal.GetListWithFilter(x => x.RoleId == 2);
            var issue = await _issueDal.GetById(id);

            if (issue == null)
                return "Görev Bulunamadı";

            var difficultyLevel = issue.DifficultyLevel;

    
            var taskProcessings = await _taskProcessingDal.GetAllWithIncludes(x => x.Issue);

            var developerTaskCounts = new Dictionary<int, Dictionary<int, int>>();
            foreach (var developer in developerList)
            {
                developerTaskCounts[developer.Id] = new Dictionary<int, int>();
                for (int level = 1; level <= 8; level++)
                {
                    developerTaskCounts[developer.Id][level] = taskProcessings.Count(t => t.EmployeeId == developer.Id && t.Issue.DifficultyLevel == level);
                }
            }

            Employee selectedDeveloper = null;

            var orderedDevelopers = developerList.OrderBy(d => developerTaskCounts[d.Id].ContainsKey(difficultyLevel) ? developerTaskCounts[d.Id][difficultyLevel] : 0);

            foreach (var developer in orderedDevelopers)
            {
      
                var employeeLevel = developer.Level;

                if (employeeLevel < difficultyLevel)
                    continue;

                if (Extensions.Extensions.CanHandleTask(taskProcessings, developer.Id, difficultyLevel, developerTaskCounts, employeeLevel))
                {
                    selectedDeveloper = developer;
                    break;
                }
            }

            if (selectedDeveloper == null)
            {
                selectedDeveloper = developerList.OrderBy(d => developerTaskCounts[d.Id].Sum(kvp => kvp.Value)).FirstOrDefault();
            }

            if (selectedDeveloper == null)
            {
                return "Görev Atanacak Uygun Geliştirici Bulunamadı";
            }

            var newTask = new TaskProcessing
            {
                EmployeeId = selectedDeveloper.Id,
                IssueId = issue.Id,
                Description = $"Görev {selectedDeveloper.Name} {selectedDeveloper.Surname} Atandı",
                Status = 1,
                IsOk = true,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await _taskProcessingDal.Insert(newTask);

            // Görevi ekledikten sonra geliştiricinin görev seviyesini güncelle
            if (!developerTaskCounts[selectedDeveloper.Id].ContainsKey(difficultyLevel))
            {
                developerTaskCounts[selectedDeveloper.Id][difficultyLevel] = 0;
            }
            developerTaskCounts[selectedDeveloper.Id][difficultyLevel]++;

            return $"Görev Ataması {selectedDeveloper.Name} {selectedDeveloper.Surname} Başarıyla Yapıldı";
        }





        public async Task<List<TaskProcessing>> TGetAllWithIncludes(params Expression<Func<TaskProcessing, object>>[] includes)
        {
            return await _taskProcessingDal.GetAllWithIncludes(includes);
        }

        public async Task<List<TaskProcessing>> TGetListWithFilter(Expression<Func<TaskProcessing, bool>> filter)
        {
            return await _taskProcessingDal.GetListWithFilter(filter);
        }

        public async Task<bool> TSearchFilter(Expression<Func<TaskProcessing, bool>> filter)
        {
            return await _taskProcessingDal.SearchFilter(filter);
        }

        public async Task TDelete(int id)
        {
            await _taskProcessingDal.Delete(id);
        }

        public async Task<List<TaskProcessing>> TGetAll()
        {
            return await _taskProcessingDal.GetAll();
        }

        public async Task<TaskProcessing> TGetById(int id)
        {
            return await _taskProcessingDal.GetById(id);
        }

        public async Task TInsert(TaskProcessing entity)
        {
            await _taskProcessingDal.Insert(entity);
        }

        public async Task TUpdate(TaskProcessing entity)
        {
            await _taskProcessingDal.Update(entity);
        }

        public async Task<TaskProcessing> TGetByIdWithIncludes(int id, params Expression<Func<TaskProcessing, object>>[] includes)
        {
            return await _taskProcessingDal.GetByIdWithIncludes(id, includes);
        }
    }
}
