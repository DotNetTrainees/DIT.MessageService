using AutoMapper;
using MessageService.Contracts;
using MessageService.Entities.DataTransferObjects.Incoming;
using MessageService.Entities.DataTransferObjects.Outgoing;
using MessageService.Entities.Models;
using MessageService.Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public MessageController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages([FromQuery] MessageParameters messageParameters)
        {
            var messages = await _repositoryManager.Message.GetAllMessagesAsync(messageParameters, trackChanges: false);
            if(messages.Count == 0 || messages == null)
            {
                return NotFound("Messages is not found");
            }

            var messagesToResponse = _mapper.Map<IEnumerable<MessageOutgoingDto>>(messages);

            return Ok(messagesToResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] MessageIncomingDto messageIncoming)
        {
            var dialogue = await _repositoryManager.Dialogue.GetDialogueByIdAsync(
                messageIncoming.DialogueId, trackChanges: false);
            if(dialogue == null)
            {
                return NotFound($"Dialogue with id {{{messageIncoming.DialogueId}}} is not found");
            }

            var messageForCreating = _mapper.Map<Message>(messageIncoming);
            _repositoryManager.Message.CreateMessage(messageForCreating);

            await _repositoryManager.SaveAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(long messageId, [FromBody] MessageIncomingDto messageIncoming)
        {

            await _repositoryManager.SaveAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(long messageId)
        {

            await _repositoryManager.SaveAsync();

            return Ok();
        }
    }
}
