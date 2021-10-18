using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MessageService.Entities.DataTransferObjects.Incoming
{
    public class DialogueIncomingDto
    {
        [Required(ErrorMessage = "First member account id is a required field.")]
        public Guid FirstMemberAccountId { get; set; }

        [Required(ErrorMessage = "Second member account id is a required field.")]
        public Guid SecondMemberAccountId { get; set; }
    }
}
