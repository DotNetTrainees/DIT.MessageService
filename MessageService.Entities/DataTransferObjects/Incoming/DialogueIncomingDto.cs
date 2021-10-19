using System;
using System.ComponentModel.DataAnnotations;

namespace MessageService.Entities.DataTransferObjects.Incoming
{
    public class DialogueIncomingDto
    {
        [Required(ErrorMessage = "First member profile id is a required field.")]
        public Guid FirstMemberProfileId { get; set; }

        [Required(ErrorMessage = "Second member profile id is a required field.")]
        public Guid SecondMemberProfileId { get; set; }
    }
}
