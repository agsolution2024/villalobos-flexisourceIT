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
    public class ActivityRepository : IActivityRepository
    {
        private IMapper _mapper;
        private RunningActivityDB _RunningActivityDB;
        protected IRunningActivityUnitofWork _IRunningActivityUnitofWork;

        public ActivityRepository(IMapper mapper, IRunningActivityUnitofWork IRunningActivityUnitofWork)
        {
            _mapper = mapper;
            _RunningActivityDB = IRunningActivityUnitofWork.DbContext;
        }

        public async Task<List<ActivityEntities>> GetById(int id)
        {
            var activity = _RunningActivityDB.Activities.Where(x => x.UserProfileId == id).ToList();
            return _mapper.Map<List<ActivityEntities>>(activity);
        }

        public async Task<ActivityEntities> Add(ActivityEntities activity)
        {
            _RunningActivityDB.Activities.Add(_mapper.Map<ActivityEntities, Activities>(activity));
            return activity;
        }

    }
}
