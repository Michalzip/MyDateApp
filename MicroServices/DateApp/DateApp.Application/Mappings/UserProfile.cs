namespace Application.Mappings
{
    internal sealed class UserMaperProfilee : Profile
    {
        public UserMaperProfilee()
        {
            CreateMap<UserProfile, UserProfileDto>();

            CreateMap<UserProfile, MessageDto>()
            .ForMember(dest => dest.Sender,
              opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Receiver,
              opt => opt.MapFrom(src => src.UserName));

            CreateMap<UserProfile, LikeDto>()
            .ForMember(dest => dest.Name,
              opt => opt.MapFrom(src => src.UserName));

        }
    }
}