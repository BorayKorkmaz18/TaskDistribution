using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDistribution.EntityLayer.Concrete
{
    public class Issue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DifficultyLevel { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
