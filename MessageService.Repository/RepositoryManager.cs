using MessageService.Contracts;
using System;
using System.Threading.Tasks;

namespace MessageService.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        public IMessageRepository Message =>
            throw new NotImplementedException();

        public IDialogueRepository Dialogue =>
            throw new NotImplementedException();

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
