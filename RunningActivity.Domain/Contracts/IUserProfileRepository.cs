using RunningActivity.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningActivity.Domain.Contracts
{
    public interface IUserProfileRepository
    {
        Task<List<UserProfileEntities>> GetAll();
        Task<UserProfileEntities> Add(UserProfileEntities userProfile);
    }
}
