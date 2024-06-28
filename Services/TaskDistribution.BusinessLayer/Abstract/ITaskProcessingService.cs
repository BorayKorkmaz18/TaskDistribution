﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDistribution.EntityLayer.Concrete;

namespace TaskDistribution.BusinessLayer.Abstract
{
    public interface ITaskProcessingService : IGenericService<TaskProcessing>
    {
        Task<string> AssignTask(int id);
    }
}
