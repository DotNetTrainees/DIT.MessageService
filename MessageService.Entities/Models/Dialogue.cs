using System;
using System.Collections.Generic;

namespace MessageService.Entities.Models
{
    public class Dialogue
    {
        public Guid Id { get; set; }

        public Guid FirstMemberProfileId { get; set; }

        public Guid SecondMemberProfileId { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
