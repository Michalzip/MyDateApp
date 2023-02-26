using AutoMapper;


namespace Application.Mappings
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<UserLike, LikeDto>()

                       .ForMember(dest => dest.Name, opt =>
                       opt.MapFrom(src => src.ByUser.UserName)
                       )

                       .ForMember(dest => dest.Name, opt =>
                       opt.MapFrom(src => src.ToUser.UserName)
                       );
        }
    }
}