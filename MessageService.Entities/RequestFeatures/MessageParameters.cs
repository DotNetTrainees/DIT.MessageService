using System;

namespace MessageService.Entities.RequestFeatures
{
    public class MessageParameters : RequestParameters
    {
        public MessageParameters()
        {
            OrderBy = "SendDate";
        }

        public string SearchTerm { get; set; }

        public long DialogueId { get; set; }

        public long ProfileId { get; set; }

        public DateTime StartDate { get; set; } = DateTime.MinValue;

        public DateTime EndDate { get; set; } = DateTime.MaxValue;
    }
}
