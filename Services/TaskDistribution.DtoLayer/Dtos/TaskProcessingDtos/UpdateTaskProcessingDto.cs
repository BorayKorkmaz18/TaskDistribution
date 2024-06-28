using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDistribution.DtoLayer.Dtos.TaskProcessingDtos
{
    public class UpdateTaskProcessingDto
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public int EmployeeId { get; set; }
        public int Statu { get; set; }
        public string? Description { get; set; }
    }
}
