using MessageService.Contracts;
using MessageService.Entities;
using System.Threading.Tasks;

namespace MessageService.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private IMessageRepository _messageRepository;
        private IDialogueRepository _dialogueRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IMessageRepository Message
        {
            get
            {
                if (_messageRepository == null)
                    _messageRepository = new MessageRepository(_repositoryContext);

                return _messageRepository;
            }
        }

        public IDialogueRepository Dialogue
        {
            get
            {
                if (_dialogueRepository == null)
                    _dialogueRepository = new DialogueRepository(_repositoryContext);

                return _dialogueRepository;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _repositoryContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
