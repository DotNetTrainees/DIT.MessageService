using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.Entities.DataTransferObjects.Outgoing
{
    public class MessageOutgoingDto
    {
        public Guid Id { get; set; }

        public Guid AccountId { get; set; }

        public Guid DialogueId { get; set; }

        public DateTime SendDate { get; set; }

        public string Text { get; set; }
    }
}
