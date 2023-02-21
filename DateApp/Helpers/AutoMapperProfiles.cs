namespace App.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<UserProfile, UserProfileDto>();

            CreateMap<UserMessage, MessageDto>()
                .ForMember(dest => dest.Sender,
                opt => opt.MapFrom(src => src.ByUser.UserName)
                )
                .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src => src.ByUser.PhotoUrl))
                .ForMember(dest => dest.Receiver,
                opt => opt.MapFrom(src => src.ToUser.UserName)
                )
                .ForMember(dest => dest.ReceiverPhotoUrl, opt =>
            opt.MapFrom(src => src.ToUser.PhotoUrl)
            );

            CreateMap<UserProfile, MessageDto>().ForMember(
                dest => dest.Sender, opt => opt.MapFrom(src => src.UserName)
                )
                .ForMember(
                dest => dest.Receiver, opt => opt.MapFrom(src => src.UserName)
            );

            CreateMap<UserLike, LikeDto>()
            .ForMember(dest => dest.Name, opt =>
            opt.MapFrom(src => src.ByUser.UserName)
            )
            .ForMember(dest => dest.Name, opt =>
            opt.MapFrom(src => src.ToUser.UserName)
            );


            CreateMap<UserProfile, LikeDto>().ForMember(
                dest => dest.Name, opt => opt.MapFrom(src => src.UserName)
                );


            CreateMap<UserTransaction, TransactionDto>()
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
             .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
              .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));



        }
    }
}

