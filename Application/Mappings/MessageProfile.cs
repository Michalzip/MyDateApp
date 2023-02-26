using AutoMapper;


namespace Application.Mappings
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<UserMessage, MessageDto>()

                            .ForMember(dest => dest.Sender,
                            opt => opt.MapFrom(src => src.ByUser.UserName)
                            )

                            .ForMember(dest => dest.SenderPhotoUrl,
                            opt => opt.MapFrom(src => src.ByUser.PhotoUrl))

                            .ForMember(dest => dest.Receiver,
                            opt => opt.MapFrom(src => src.ToUser.UserName)
                            )

                            .ForMember(dest => dest.ReceiverPhotoUrl, opt =>
                            opt.MapFrom(src => src.ToUser.PhotoUrl)
                        );

        }
    }
}