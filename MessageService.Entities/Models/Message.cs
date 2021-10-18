using System;

namespace MessageService.Entities.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        public Guid DialogueId { get; set; }

        public Dialogue Dialogue { get; set; }

        public Guid AccountId { get; set; }

        public DateTime SendDate { get; set; }

        public string Text { get; set; }
    }
}
