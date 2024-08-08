using AutoMapper;
using RunningActivity.Domain.Contracts;
using RunningActivity.Infrastructure.DBContext;
using RunningActivity.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningActivity.Infrastructure.Repository
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IRunningActivityUnitofWork _runningActivityUnitOfWork;

        public UserProfileService(IMapper mapper, IRunningActivityUnitofWork runningActivityUnitOfWork, IUserProfileRepository userProfileRepository)
        {
            _mapper = mapper;
            _runningActivityUnitOfWork = runningActivityUnitOfWork;
            _userProfileRepository = userProfileRepository;
        }

        public async Task<List<UserProfileDto>> GetAll()
        {
            var userProfiles = await _userProfileRepository.GetAll();
            return _mapper.Map<List<UserProfileDto>>(userProfiles);
        }

        public async Task<UserProfileDto> Add(UserProfileDto userProfile)
        {
            var userProfileEntity = _mapper.Map<UserProfileDto, UserProfileEntities>(userProfile);
            _userProfileRepository.Add(userProfileEntity);
            await _runningActivityUnitOfWork.SaveAsync();
            return userProfile;
        }
    }
}
