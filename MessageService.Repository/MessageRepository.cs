using MessageService.Contracts;
using MessageService.Entities;
using MessageService.Entities.Models;
using MessageService.Entities.RequestFeatures;
using MessageService.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MessageService.Repository
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }

        public async Task<PagedList<Message>> GetAllMessagesAsync(MessageParameters messageParameters,
            bool trackChanges)
        {
            var messages = await FindAll(trackChanges)
                .FilterByDate(messageParameters.StartDate, messageParameters.EndDate)
                .Search(messageParameters.SearchTerm)
                .Sort(messageParameters.OrderBy)
                .ToListAsync();

            return PagedList<Message>
                .ToPagedList(messages, messageParameters.PageNumber, messageParameters.PageSize);
        }

        public async Task<Message> GetMessageByIdAsync(long messageId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(messageId), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateMessage(Message message) =>
            Create(message);

        public void DeleteMessage(Message message) =>
            Delete(message);

    }
}
