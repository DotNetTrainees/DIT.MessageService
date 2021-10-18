using System;

namespace MessageService.Entities.DataTransferObjects.Outgoing
{
    public class DialogueOutgoingDto
    {
        public Guid Id { get; set; }

        public Guid FirstMemberAccountId { get; set; }

        public Guid SecondMemberAccountId { get; set; }
    }
}
