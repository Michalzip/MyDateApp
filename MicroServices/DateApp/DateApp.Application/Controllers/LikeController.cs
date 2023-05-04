using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("dateapp/[controller]")]
    [Authorize(Policy = "UserProfile")]
    public class LikeController : Controller
    {
        private readonly ILikeService _likeService;
        private readonly IMapper _mapper;

        public LikeController(ILikeService likeService, IMapper mapper)
        {
            _mapper = mapper;
            _likeService = likeService;
        }

        private string? sourceUserName;

        [HttpGet("get-liked-profiles")]
        public async Task<ActionResult<PagedList<LikeDto>>> GetLikedProfiles([FromQuery] PaginationParams paginationParams)
        {
            sourceUserName = User.GetUsername();

            var result = await _likeService.GetLikedProfiles(sourceUserName);

            if (result.Count == 0) return NotFound("you  didn't like users");

            var likedProfilesDto = _mapper.Map<List<UserLike>, List<LikeDto>>(result);

            return Ok(PagedList<LikeDto>.ToPagedList(likedProfilesDto,
                 paginationParams.PageNumber,
                 paginationParams.PageSize));
        }

        [HttpGet("get-likes-profiles")]
        public async Task<ActionResult<PagedList<LikeDto>>> GetLikesProfiles([FromQuery] PaginationParams paginationParams)
        {
            sourceUserName = User.GetUsername();

            var result = await _likeService.GetLikesProfiles(sourceUserName);

            if (result.Count == 0) return NotFound("any user like your profile yet");

            var likesProfilesDto = _mapper.Map<List<UserLike>, List<LikeDto>>(result);

            return Ok(PagedList<LikeDto>.ToPagedList(likesProfilesDto,
                 paginationParams.PageNumber,
                 paginationParams.PageSize));
        }

        [HttpPost("add-like")]
        public async Task<ActionResult> AddLike(string username)
        {
            sourceUserName = User.GetUsername();

            await _likeService.CreateLikeFromQuery(sourceUserName, username);

            return Ok("Like Added");
        }
    }
}



