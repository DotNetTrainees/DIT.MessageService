using System;
using System.Collections.Generic;

namespace MessageService.Entities.Models
{
    public class Dialogue
    {
        public Guid Id { get; set; }

        public Guid FirstMemberAccountId { get; set; }

        public Guid SecondMemberAccountId { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
