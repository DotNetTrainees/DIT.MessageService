using System;
using System.ComponentModel.DataAnnotations;

namespace MessageService.Entities.DataTransferObjects.Incoming
{
    public class MessageIncomingDto
    {
        [Required(ErrorMessage = "Profile id is a required field.")]
        public Guid ProfileId { get; set; }

        [Required(ErrorMessage = "Dialogue id is a required field.")]
        public Guid DialogueId { get; set; }

        [Required(ErrorMessage = "Send date is a required field.")]
        public DateTime SendDate { get; set; }

        [MaxLength(3000, ErrorMessage = "Maximum length for text is 3000 characters.")]
        public string Text { get; set; }
    }
}
