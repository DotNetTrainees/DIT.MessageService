using System;

namespace MessageService.Entities.DataTransferObjects.Outgoing
{
    public class DialogueOutgoingDto
    {
        public Guid Id { get; set; }

        public Guid FirstMemberProfileId { get; set; }

        public Guid SecondMemberProfileId { get; set; }
    }
}
