

namespace App.Helpers
{
	public class AutoMapperProfiles: Profile
    {
		public AutoMapperProfiles()
		{

			CreateMap<UserProfile, UserGetProfileDto>();
			CreateMap<UserMessage, MessageGetDto>()
				.ForMember(dest => dest.Sender,
				opt => opt.MapFrom(src => src.ByUserMessage.UserName)
				).ForMember(dest => dest.Receiver,
				opt => opt.MapFrom(src => src.ToUserMessage.UserName)
				);


            CreateMap<UserProfile, MessageGetDto>().ForMember(
				dest=>dest.Sender,opt=>opt.MapFrom(src=>src.UserName)
				).ForMember(
                dest => dest.Receiver, opt => opt.MapFrom(src => src.UserName)
                ); ;


        }
	}
}

