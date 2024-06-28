using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDistribution.EntityLayer.Concrete;

namespace TaskDistribution.DtoLayer.Dtos.EmployeeDtos
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Level { get; set; }
        public int RoleId { get; set; }
    }
}
