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
    public class ActivityService : IActivityService
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _IActivityRepository;
        private readonly IRunningActivityUnitofWork _runningActivityUnitOfWork;

        public ActivityService(IMapper mapper, IRunningActivityUnitofWork runningActivityUnitOfWork, IActivityRepository IActivityRepository)
        {
            _mapper = mapper;
            _runningActivityUnitOfWork = runningActivityUnitOfWork;
            _IActivityRepository = IActivityRepository;
        }

        public async Task<List<ActivityDto>> GetById(int id)
        {
            var activity = await _IActivityRepository.GetById(id);
            return _mapper.Map<List<ActivityDto>>(activity);
        }

        public async Task<ActivityDto> Add(ActivityDto activity)
        {
            var activityEntity = _mapper.Map<ActivityDto, ActivityEntities>(activity);
            _IActivityRepository.Add(activityEntity);
            await _runningActivityUnitOfWork.SaveAsync();
            return activity;
        }
    }
}
