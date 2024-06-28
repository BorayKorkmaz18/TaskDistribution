using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDistribution.DtoLayer.Dtos.IssueDtos
{
    public class UpdateIssueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Severity { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
