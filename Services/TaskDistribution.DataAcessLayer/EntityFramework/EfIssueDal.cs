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
    public class EfIssueDal : GenericRepositories<Issue>, IIssueDal
    {
        public EfIssueDal(TaskDistributionContext context) : base(context)
        {
        }
    }
}
