using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DateApp.Extensions;
using DateApp.DTOs;


namespace Api.Controllers
{
    [Authorize(Policy = "UserProfile")]
    public class LikeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LikeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private string? sourceUserName;


        [HttpGet("GetLikedUsers")]
        public async Task<ActionResult<LikeDto>> GetLikedUsers()
        {


            sourceUserName = User.GetUsername();

            var likesBySourceUser = await _unitOfWork.LikeRepository.GetLikedUsers(sourceUserName);

            if (likesBySourceUser == null) return BadRequest("you  didn't like users");

            var likesDto = _mapper.Map<List<UserLike>, List<LikeDto>>(likesBySourceUser);

            return Ok(likesDto);

        }


        [HttpGet("GetLikeUsers")]
        public async Task<ActionResult<LikeDto>> GetLikeUsers()
        {


            sourceUserName = User.GetUsername();

            var likeFromUsers = await _unitOfWork.LikeRepository.GetLikeUsers(sourceUserName);


            if (likeFromUsers.Count == 0) return BadRequest("No user liked you yet");

            var likesDto = _mapper.Map<List<UserLike>, List<LikeDto>>(likeFromUsers);



            return Ok(likesDto);

        }


        [HttpPost("AddLike")]
        public async Task<ActionResult> AddLike(LikeCreateDto user)
        {

            sourceUserName = User.GetUsername();

            var currentUser = await _unitOfWork.UserRepository.GetUser(sourceUserName);

            var receiverUser = await _unitOfWork.UserRepository.GetUser(user.UserName);

            if (receiverUser == null) return NotFound("Not Found user");

            var like = new UserLike
            {
                ByUser = currentUser,
                ToUser = receiverUser,
            };

            bool result = await _unitOfWork.LikeRepository.CheckExistsLike(like);

            if (result == true) return BadRequest("u can't like user twice");

            _unitOfWork.LikeRepository.AddLike(like);

            if (await _unitOfWork.Complete()) return Ok("Like Added");

            return BadRequest("Like Not Added");
        }
    }
}

