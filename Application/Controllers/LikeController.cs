using Microsoft.AspNetCore.Mvc;



namespace Application.Controllers
{
    [Authorize(Policy = "UserProfile")]
    public class LikeController : Controller
    {


        private readonly ILikeService _likeService;
   
        public LikeController(ILikeService likeService)
        {

           
            _likeService = likeService;
        }

        private string? sourceUserName;


        [HttpGet("get-liked-profiles")]
        public async Task<ActionResult<PagedList<LikeDto>>> GetLikedProfiles([FromQuery] PaginationParams paginationParams)
        {

            sourceUserName = User.GetUsername();

            var result = await _likeService.GetLikedProfiles(sourceUserName);

            if (result.Count == 0) return NotFound("you  didn't like users");

            return Ok(PagedList<LikeDto>.ToPagedList(result,
                 paginationParams.PageNumber,
                 paginationParams.PageSize));


        }


        [HttpGet("get-likes-profiles")]
        public async Task<ActionResult<PagedList<LikeDto>>> GetLikesProfiles([FromQuery] PaginationParams paginationParams)
        {

            sourceUserName = User.GetUsername();

            var result = await _likeService.GetLikesProfiles(sourceUserName);

            if (result.Count == 0) return NotFound("any user like your profile yet");


            return Ok(PagedList<LikeDto>.ToPagedList(result,
                 paginationParams.PageNumber,
                 paginationParams.PageSize));

        }


        [HttpPost("add-like")]
        public async Task<ActionResult> AddLike(string toUser)
        {

            sourceUserName = User.GetUsername();

            var result = await _likeService.CreateLikeFromQuery(sourceUserName, toUser);

            if (result == 0) return BadRequest("u can't like user twice");

            return Ok("Like Added");

        }
    }
}



