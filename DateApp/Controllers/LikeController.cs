using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DateApp.Extensions;
using DateApp.DTOs;
using DateApp.Services.Interfaces;

namespace Api.Controllers
{
    [Authorize(Policy = "UserProfile")]
    public class LikeController : Controller
    {

        private readonly IMapper _mapper;
        private readonly ILikeService _likeService;
        public LikeController(IMapper mapper, ILikeService likeService)
        {

            _mapper = mapper;
            _likeService = likeService;
        }

        private string? sourceUserName;


        [HttpGet("GetLikedProfiles")]
        public async Task<ActionResult<LikeDto>> GetLikedProfiles()
        {


            sourceUserName = User.GetUsername();

            var result = await _likeService.GetLikedProfiles(sourceUserName);

            if (result == null) return BadRequest("you  didn't like users");

            return Ok(result);


        }


        [HttpGet("GetLikesProfiles")]
        public async Task<ActionResult<LikeDto>> GetLikesProfiles()
        {



            sourceUserName = User.GetUsername();

            var result = await _likeService.GetLikesProfiles(sourceUserName);

            if (result == null) return BadRequest("any user like your profile yet");

            return Ok(result);



        }


        [HttpPost("AddLike")]
        public async Task<ActionResult> AddLike(string toUser)
        {

            sourceUserName = User.GetUsername();

            var result = await _likeService.CreateLikeFromQuery(sourceUserName, toUser);

            if (result != null) return Ok("Like Added" + result);

            return BadRequest("u can't like user twice");

        }
    }
}



