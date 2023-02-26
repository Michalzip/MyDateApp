

using Microsoft.AspNetCore.Mvc;
using DateApp.Extensions;
using DateApp.Helpers;


namespace Api.Controllers
{
    [Authorize(Policy = "UserProfile")]
    public class MessageController : Controller
    {




        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {


            _messageService = messageService;
        }

        private string? sourceUserName;

        [HttpGet("get-messagess")]

        public async Task<ActionResult<PagedList<MessageDto>>> GetMessages(string username, [FromQuery] PaginationParams paginationParams)
        {
            sourceUserName = User.GetUsername();

            var messages = await _messageService.GetAllMessages(sourceUserName, username);

            var messagesDto = _mapper.Map<List<UserMessage>, List<MessageDto>>(messages);

            if (messagesDto.Count() == 0) return BadRequest("you dont have messages with this user");

            return PagedList<MessageDto>.ToPagedList(messagesDto,
                 paginationParams.PageNumber,
                  paginationParams.PageSize);

        }


        [HttpGet("get-messagess-by-time")]

        public async Task<ActionResult<MessageDto>> GetMessagesByTime(string username, int hourFrom, int hourTo, int day)
        {

            var sourceUser = User.GetUsername();

            var messagesByTime = await _messageService.GetMessageByTime(sourceUser, username, hourTo, hourFrom, day);

            var messagesDto = _mapper.Map<List<UserMessage>, List<MessageDto>>(messagesByTime);

            if (messagesDto.Count == 0) return BadRequest("You have no messages with this user in the time limit");

            return Ok(messagesDto);



        }

        [HttpPost("add-message")]

        public async Task<ActionResult> AddMessages(MessageCreateDto user)
        {


            sourceUserName = User.GetUsername();

            var result = await _messageService.CreateMessageFromQuery(sourceUserName, user.UserName, user.Message);

            if (result == 0) return BadRequest("Message Not Added");

            return Ok("Message added successfully");

        }



        [HttpDelete("delete-message")]
        public async Task<ActionResult> DeleteMessage(int id)
        {

            var result = await _messageService.DeleteMessageById(id);

            if (result == 0) return BadRequest("Problem Deleting the message");

            return Ok("Message Delete");

        }


    }
}

