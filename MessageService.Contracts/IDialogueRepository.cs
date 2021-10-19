using MessageService.Entities.Models;
using MessageService.Entities.RequestFeatures;
using System;
using System.Threading.Tasks;

namespace MessageService.Contracts
{
    public interface IDialogueRepository
    {
        public Task<PagedList<Dialogue>> GetAllDialoguesAsync(DialogueParameters dialogueParameters, bool trackChanges);

        public Task<Dialogue> GetDialogueByIdAsync(Guid dialogueId, bool trackChanges);

        public Task<Dialogue> GetDialogueByMemberIdsAsync(Guid firstMemberId, Guid secondMemberId, bool trackChanges);

        public void CreateDialogue(Dialogue dialogue);

        public void DeleteDialogue(Dialogue dialogue);
    }
}
