using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RunningActivity.Domain.Contracts;
using RunningActivity.Infrastructure.DBContext;
using RunningActivity.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RunningActivity.Infrastructure.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private IMapper _mapper;
        private RunningActivityDB _RunningActivityDB;
        protected IRunningActivityUnitofWork _IRunningActivityUnitofWork;

        public UserProfileRepository(IMapper mapper, IRunningActivityUnitofWork IRunningActivityUnitofWork)
        {
            _mapper = mapper;
            _RunningActivityDB = IRunningActivityUnitofWork.DbContext;
        }

        public async Task<List<UserProfileEntities>> GetAll()
        {
            var userProfiles = _RunningActivityDB.UserProfiles.ToList();
            return _mapper.Map<List<UserProfileEntities>>(userProfiles);
        }

        public async Task<UserProfileEntities> Add(UserProfileEntities userProfile)
        {
            _RunningActivityDB.UserProfiles.Add(_mapper.Map<UserProfileEntities, UserProfile>(userProfile));
            return userProfile;
        }

    }
}
