using Microsoft.AspNetCore.Mvc;


namespace App.Controllers
{
    [Authorize]
    public class UserController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet("GetUserByName")]
        public async Task<ActionResult<UserProfileDto>> GetUser(string username)
        {

            var user = await _unitOfWork.UserRepository.GetUser(username);

            if (user != null) return Ok(_mapper.Map<UserProfile, UserProfileDto>(user));

            return NotFound("Not Found User");
        }




        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserProfileDto>> CreateUser(UserCreateProfileDto model)
        {

            var userProfile = await _mediator.Send(model);

            _unitOfWork.UserRepository.AddUserProfile(userProfile);

            if (await _unitOfWork.Complete()) return Ok(_mapper.Map<UserProfile, UserProfileDto>(userProfile));

            return BadRequest("Failed To Create UserProfile");


        }

    }
}

