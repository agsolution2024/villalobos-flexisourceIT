using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Mvc;
using RunningActivity.Domain.Contracts;
using RunningActivity.Infrastructure.Model;
using RunningActivity.Infrastructure.Repository;
namespace RunningActivity.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class RunningActivityController : ControllerBase
    {

        private IUserProfileService _IUserProfileService;
        private IActivityService _IActivityService;
        private IMapper _mapper;
        private ILog _log = LogManager.GetLogger(typeof(RunningActivityController));


        public RunningActivityController(IUserProfileService IUserProfileService, IMapper mapper, IActivityService iActivityService)
        {
            _IUserProfileService = IUserProfileService;
            _IActivityService = iActivityService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserProfileDto>>> GetUserProfiles()
        {
            try
            {
                _log.Info("GetUserProfiles method called");
                var userProfiles = await _IUserProfileService.GetAll();
                if (userProfiles == null)
                {
                    _log.Info("GetUserProfiles NotFound");
                    return NotFound();
                   
                }

                var userProfileDtos = _mapper.Map<List<UserProfileDto>>(userProfiles);
                return Ok(userProfileDtos);
            }
            catch (Exception ex)
            {
                _log.Info($"Internal server error: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        [HttpPost]
        public async Task<ActionResult<List<UserProfileDto>>> AddUserProfiles(UserProfileDto userProfiles)
        {
            try
            {
                _log.Info("AddUserProfiles method calledss");
                var _userProfiles = await _IUserProfileService.Add(userProfiles);
                return CreatedAtAction(nameof(GetUserProfiles), new { id = _userProfiles.Id }, _userProfiles);
            }
            catch (Exception ex)
            {

                _log.Info($"Internal server error: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        [HttpGet("activities/{id}")]
        public async Task<ActionResult<List<ActivityDto>>> GetRunningActivityById(int id)
        {
            try
            {
                var activity = await _IActivityService.GetById(id);
                if (activity.Count() == 0)
                {
                    return NotFound();
                }
                else
                {
                    var _activity = _mapper.Map<List<ActivityDto>>(activity);
                    return Ok(_activity);
                }

            }
            catch (Exception ex)
            {

                _log.Info($"Internal server error: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        [HttpPost("activities")]
        public async Task<ActionResult<List<ActivityDto>>> AddUserActivity(ActivityDto activity)
        {
            try
            {
                var _activity = await _IActivityService.Add(activity);
                return CreatedAtAction(nameof(GetUserProfiles), new { id = _activity.Id }, _activity);
            }
            catch (Exception ex)
            {

                _log.Info($"Internal server error: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

    }
}
