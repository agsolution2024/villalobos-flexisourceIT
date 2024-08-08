using RunningActivity.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningActivity.Domain.Contracts
{
    public interface IUserProfileService
    {
        Task<List<UserProfileDto>> GetAll();
        Task<UserProfileDto> Add(UserProfileDto userProfile);
    }
}
