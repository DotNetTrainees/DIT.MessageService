using AutoMapper;
using MessageService.Entities.DataTransferObjects.Incoming;
using MessageService.Entities.DataTransferObjects.Outgoing;
using MessageService.Entities.Models;

namespace MessageService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Message, MessageOutgoingDto>();
            CreateMap<MessageIncomingDto, Message>();

            CreateMap<Dialogue, DialogueOutgoingDto>();
            CreateMap<DialogueIncomingDto, Dialogue>();
        }
    }
}
