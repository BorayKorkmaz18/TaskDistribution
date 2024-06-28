using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDistribution.DataAcessLayer.Abstract;
using TaskDistribution.DataAcessLayer.Concrete;
using TaskDistribution.DataAcessLayer.Repositories;
using TaskDistribution.EntityLayer.Concrete;

namespace TaskDistribution.DataAcessLayer.EntityFramework
{
    public class EfRoleDal : GenericRepositories<Role>, IRoleDal
    {
        public EfRoleDal(TaskDistributionContext context) : base(context)
        {
        }
    }
}
