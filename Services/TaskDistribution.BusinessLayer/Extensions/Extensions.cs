using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDistribution.EntityLayer.Concrete;

namespace TaskDistribution.BusinessLayer.Extensions
{
    public static class Extensions
    {

        public static bool CanHandleTask(List<TaskProcessing> taskProcessings, int employeeId, int difficultyLevel, Dictionary<int, Dictionary<int, int>> developerTaskCounts, int employeeLevel)
        {
            if (difficultyLevel > employeeLevel)
                return false;

            var assignedTasks = taskProcessings.Where(t => t.EmployeeId == employeeId && t.Issue.DifficultyLevel == difficultyLevel);
            return assignedTasks.Count() == 0;
        }
    }
}
