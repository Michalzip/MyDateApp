using Microsoft.AspNetCore.Mvc;
namespace Application.Controllers
{
    [Route("dateapp/[controller]")]
    [Authorize(Policy = "UserProfile")]
    public class MessageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMessageService _messageService;


        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        private string? sourceUserName;

        [HttpGet("get-messagess")]

        public async Task<ActionResult<PagedList<MessageDto>>> GetMessages(string username, [FromQuery] PaginationParams paginationParams)
        {
            sourceUserName = User.GetUsername();

            var messages = await _messageService.GetAllMessages(sourceUserName, username);

            if (messages.Count == 0) return NotFound("you dont have messages with this user");

            var messagesDto = _mapper.Map<List<UserMessage>, List<MessageDto>>(messages);

            return PagedList<MessageDto>.ToPagedList(messagesDto,
                 paginationParams.PageNumber,
                  paginationParams.PageSize);
        }

        [HttpGet("get-messagess-by-time")]

        public async Task<ActionResult<MessageDto>> GetMessagesByTime(string username, int hourFrom, int hourTo, int day)
        {
            var sourceUser = User.GetUsername();

            var messagesByTime = await _messageService.GetMessageByTime(sourceUser, username, hourTo, hourFrom, day);

            if (messagesByTime.Count == 0) return NotFound("You have no messages with this user in the time limit");

            var messagesDto = _mapper.Map<List<UserMessage>, List<MessageDto>>(messagesByTime);

            return Ok(messagesDto);
        }

        [HttpPost("add-message")]
        public async Task<ActionResult> AddMessages(MessageCreateDto user)
        {
            sourceUserName = User.GetUsername();

            await _messageService.CreateMessageFromQuery(sourceUserName, user.UserName, user.Message);

            return Ok("Message added successfully");
        }

        [HttpDelete("delete-message")]
        public async Task<ActionResult> DeleteMessage(int id)
        {
            await _messageService.DeleteMessageById(id);

            return Ok("Message Delete");
        }
    }
}
