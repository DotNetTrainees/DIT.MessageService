using System.Threading.Tasks;

namespace MessageService.Contracts
{
    public interface IRepositoryManager
    {
        public IMessageRepository Message { get; }

        public IDialogueRepository Dialogue { get; }

        public Task SaveAsync();
    }
}
