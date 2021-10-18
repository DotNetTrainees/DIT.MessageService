using MessageService.Entities.Models;
using MessageService.Entities.RequestFeatures;
using System.Threading.Tasks;

namespace MessageService.Contracts
{
    public interface IMessageRepository
    {
        public Task<PagedList<Message>> GetAllMessagesAsync(MessageParameters messageParameters,
             bool trackChanges);

        public Task<Message> GetMessageAsync(int messageId, bool trackChanges);

        public void CreateMessage(Message message);

        public void DeleteMessage(Message message);
    }
}
