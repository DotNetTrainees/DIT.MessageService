using System;
using System.ComponentModel.DataAnnotations;

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
