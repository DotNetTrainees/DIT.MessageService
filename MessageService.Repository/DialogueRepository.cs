using MessageService.Contracts;
using MessageService.Entities;
using MessageService.Entities.Models;
using MessageService.Entities.RequestFeatures;
using MessageService.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository
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
                .ToPagedList(dialogues, dialogueParameters.PageNumber,
                    dialogueParameters.PageSize);
        }

        public async Task<Dialogue> GetDialogueAsync(int dialogueId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(dialogueId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateDialogue(Dialogue dialogue) =>
            Create(dialogue);

        public void DeleteDialogue(Dialogue dialogue) =>
            Delete(dialogue);
    }
}