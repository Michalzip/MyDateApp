

using Microsoft.AspNetCore.Mvc;
using DateApp.Extensions;
using DateApp.Helpers;
using DateApp.Services.Interfaces;

namespace Api.Controllers
{
    [Authorize(Policy = "UserProfile")]
    public class MessageController : Controller
    {

        private readonly IMapper _mapper;


        private readonly IMessageService _messageService;

        public MessageController(IMapper mapper, IMessageService messageService)
        {
            _mapper = mapper;

            _messageService = messageService;
        }

        private string? sourceUserName;

        [HttpGet("GetMessages")]

        public async Task<ActionResult<PagedList<MessageDto>>> GetMessages(string username, [FromQuery] PaginationParams paginationParams)
        {
            sourceUserName = User.GetUsername();

            // var messages = await _unitOfWork.MessageRepository.GetMessages(sourceUserName, username);

            // if (messages.Count() == 0) return BadRequest("you dont have messages with this user");

            // var result = _mapper.Map<List<UserMessage>, List<MessageDto>>(messages);

            // return PagedList<MessageDto>.ToPagedList(result,
            //    paginationParams.PageNumber,
            //    paginationParams.PageSize);

        }


        [HttpGet("GetMessagesByTime")]

        public async Task<ActionResult<MessageDto>> GetMessagesByTime(string username, int hourFrom, int hourTo, int day)
        {

            var sourceUser = User.GetUsername();

            // var message = new MessageDto
            // {
            //     Sender = sourceUser,
            //     Receiver = username
            // };

            // var messages = await _unitOfWork.MessageRepository.GetMessagesByTime(message, hourFrom, hourTo, day);

            // if (messages.Count() == 0) return BadRequest("You have no messages with this user in the time limit");

            // var result = _mapper.Map<List<UserMessage>, List<MessageDto>>(messages);

            // return Ok(result);

        }

        [HttpPost("AddMessages")]

        public async Task<ActionResult<MessageDto>> AddMessages(MessageCreateDto user)
        {


            sourceUserName = User.GetUsername();

            // var sourceUser = await _unitOfWork.UserRepository.GetUser(sourceUserName);

            // var receiverUser = await _unitOfWork.UserRepository.GetUser(user.UserName);

            // if (receiverUser == null) return NotFound("Not Found user");


            // var message = new UserMessage
            // {
            //     ByUser = sourceUser,
            //     ToUser = receiverUser,
            //     Message = user.Message,
            // };

            // _unitOfWork.MessageRepository.AddMessage(message);

            // var messageDto = _mapper.Map<UserMessage, MessageDto>(message);

            // if (await _unitOfWork.Complete()) return Ok(messageDto);

            // return BadRequest("Message Not Added");

        }



        [HttpDelete("DeleteMessage")]
        public async Task<ActionResult> DeleteMessage(int id)
        {

            // var result = await _messageService.DeleteMessageById(id);

            // if (result == false) return BadRequest("Problem Deleting the message");

            // return Ok("Message Delete");



        }


    }
}

