using AutoMapper;
using MessageService.Contracts;
using MessageService.Entities.DataTransferObjects.Incoming;
using MessageService.Entities.DataTransferObjects.Outgoing;
using MessageService.Entities.Models;
using MessageService.Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DialogueController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public DialogueController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDialogues([FromQuery] DialogueParameters dialogueParameters)
        {
            var dialogues = await _repositoryManager.Dialogue.GetAllDialoguesAsync(dialogueParameters, trackChanges: false);
            if(dialogues.Count == 0 || dialogues == null)
            {
                return NotFound("Dialogues is not found");
            }

            var dialoguesToResponse = _mapper.Map<IEnumerable<DialogueOutgoingDto>>(dialogues);

            return Ok(dialoguesToResponse);
        }

        [HttpGet("{dialogueId}")]
        public async Task<IActionResult> GetDialogueById(Guid dialogueId)
        {
            var dialogue = await _repositoryManager.Dialogue.GetDialogueByIdAsync(dialogueId, trackChanges: false);
            if (dialogue == null)
            {
                return NotFound("Dialogues is not found");
            }

            var dialogueToResponse = _mapper.Map<DialogueOutgoingDto>(dialogue);

            return Ok(dialogueToResponse);
        }

        [HttpGet("{firstMemberId}/{secondMemberId}")]
        public async Task<IActionResult> GetDialogueByMemberIds(Guid firstMemberId, Guid secondMemberId)
        {
            var dialogue = await _repositoryManager.Dialogue.GetDialogueByMemberIdsAsync(
                firstMemberId, 
                secondMemberId, 
                trackChanges: false);
            if (dialogue == null)
            {
                return NotFound("Dialogues is not found");
            }

            var dialogueToResponse = _mapper.Map<DialogueOutgoingDto>(dialogue);

            return Ok(dialogueToResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDialogue([FromBody] DialogueIncomingDto dialogueIncoming)
        {
            var dialogueForCreating = _mapper.Map<Dialogue>(dialogueIncoming);

            _repositoryManager.Dialogue.CreateDialogue(dialogueForCreating);

            await _repositoryManager.SaveAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDialogue(Guid dialogueId)
        {
            var dialogue = await _repositoryManager.Dialogue.GetDialogueByIdAsync(dialogueId, trackChanges: false);
            if (dialogue == null)
            {
                return NotFound($"Dialogue with id {{{dialogueId}}} is not found");
            }

            _repositoryManager.Dialogue.DeleteDialogue(dialogue);

            await _repositoryManager.SaveAsync();

            return NoContent();
        }
    }
}
