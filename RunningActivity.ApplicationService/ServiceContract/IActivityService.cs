using RunningActivity.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningActivity.Domain.Contracts
{
    public interface IActivityService
    {
        Task<List<ActivityDto>> GetById(int id);
        Task<ActivityDto> Add(ActivityDto activity);
        //Task<List<UserProfileDto>> GetAll();
        //Task<UserProfileDto> Add(UserProfileDto userProfile);
    }
}
