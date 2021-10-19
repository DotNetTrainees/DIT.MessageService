using MessageService.Contracts;
using MessageService.Entities;
using MessageService.Entities.Models;
using MessageService.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MessageService.Repository
{
    public class DialogueRepository : RepositoryBase<Dialogue>, IDialogueRepository
    {
        public DialogueRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }

        public async Task<PagedList<Dialogue>> GetAllDialoguesAsync(DialogueParameters dialogueParameters,
            bool trackChanges)
        {
            var dialogues = await FindAll(trackChanges)
                .ToListAsync();

            return PagedList<Dialogue>
                .ToPagedList(dialogues, dialogueParameters.PageNumber, dialogueParameters.PageSize);
        }

        public async Task<Dialogue> GetDialogueByIdAsync(Guid dialogueId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(dialogueId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<Dialogue> GetDialogueByMemberIdsAsync(Guid firstMemberId, Guid secondMemberId, bool trackChanges) =>
            await FindByCondition(c =>
                (c.FirstMemberProfileId.Equals(firstMemberId) || c.SecondMemberProfileId.Equals(firstMemberId)) &&
                (c.FirstMemberProfileId.Equals(secondMemberId) || c.SecondMemberProfileId.Equals(secondMemberId)), 
                    trackChanges)
                .SingleOrDefaultAsync();

        public void CreateDialogue(Dialogue dialogue) =>
            Create(dialogue);

        public void DeleteDialogue(Dialogue dialogue) =>
            Delete(dialogue);

    }
}