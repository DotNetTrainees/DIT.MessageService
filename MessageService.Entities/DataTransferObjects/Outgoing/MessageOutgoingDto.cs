using System;

namespace MessageService.Entities.DataTransferObjects.Outgoing
{
    public class MessageOutgoingDto
    {
        public long Id { get; set; }

        public Guid ProfileId { get; set; }

        public Guid DialogueId { get; set; }

        public DateTime SendDate { get; set; }

        public string Text { get; set; }
    }
}
