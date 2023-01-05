

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Policy = "UserProfile")]
    public class MessageController : Controller
    {
 
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MessageController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        private string? currentUserName;

        [HttpGet("GetMessage")]

        public async Task<ActionResult<MessageGetDto>> GetMessages(string name)
        {
            currentUserName = User.Identity.Name;

            if (currentUserName == null) return BadRequest("User Not Logged In");

            var messages = await _unitOfWork.MessageRepository.GetConversation(currentUserName , name);

            var result = _mapper.Map<List<UserMessage>, List<MessageGetDto>>(messages);

            return Ok(result);

          

        }


        [HttpPost("CreateMessages")]

        public async Task<ActionResult<MessageGetDto>> CreateMessages(MessageCreateDto user)
        {
           

            currentUserName = User.Identity.Name;

            var currentUser =  await _unitOfWork.UserRepository.GetUser(currentUserName);

            var receiverUser = await _unitOfWork.UserRepository.GetUser(user.UserName);

            if (receiverUser == null) return NotFound("Not Found user");


            var message = new UserMessage
            {
                ByUserMessage = currentUser,
                ToUserMessage = receiverUser,
                Message = user.Message,
            };

            _unitOfWork.MessageRepository.AddMessage(message);

            var result =   _mapper.Map<UserMessage, MessageGetDto>(message);

            if (await _unitOfWork.Complete()) return Ok(result);

            return BadRequest("Message Not Added");

        }


    }
}

