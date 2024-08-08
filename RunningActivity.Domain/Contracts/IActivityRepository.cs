using RunningActivity.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningActivity.Domain.Contracts
{
    public interface IActivityRepository
    {
        Task<List<ActivityEntities>> GetById(int id);
        Task<ActivityEntities> Add(ActivityEntities activity);
    }
}
