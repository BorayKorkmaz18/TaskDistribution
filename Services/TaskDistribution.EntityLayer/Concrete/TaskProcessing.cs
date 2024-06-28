using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDistribution.EntityLayer.Concrete
{
    public class TaskProcessing
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
        public int EmployeeId { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public bool IsOk { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

