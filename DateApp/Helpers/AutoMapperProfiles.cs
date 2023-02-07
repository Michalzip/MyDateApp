

using Api.DTOs;
using DateApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using DateApp.Repositories;
using Microsoft.AspNetCore.Session;
using PayPal.Api;
using Api.Extensions;
using System;
using DateApp.Repositories.Interfaces;
using DateApp.Extensions;
using Api.Repository;
using DateApp.Entities;

namespace App.Helpers
{
	public class AutoMapperProfiles: Profile
    {
		public AutoMapperProfiles()
		{

			CreateMap<UserProfile, UserProfileDto>();

			CreateMap<UserMessage, MessageDto>()
				.ForMember(dest => dest.Sender,
				opt => opt.MapFrom(src => src.ByUser.UserName)
				)
				.ForMember(dest=>dest.SenderPhotoUrl,opt=>opt.MapFrom(src=>src.ByUser.PhotoUrl))
				.ForMember(dest => dest.Receiver,
				opt => opt.MapFrom(src => src.ToUser.UserName)
				)
				.ForMember(dest=>dest.ReceiverPhotoUrl,opt=>
			opt.MapFrom(src=>src.ToUser.PhotoUrl)
			);

            CreateMap<UserProfile, MessageDto>().ForMember(
				dest=>dest.Sender,opt=>opt.MapFrom(src=>src.UserName)
				)
				.ForMember(
                dest => dest.Receiver, opt => opt.MapFrom(src => src.UserName)
            );

			CreateMap<UserLike, LikeCreateDto>();

			CreateMap<UserLike, LikeDto>()
			.ForMember(dest=>dest.Name,opt=>
			opt.MapFrom(src=>src.ByUser.UserName)
			).ForMember(dest=>dest.Name,opt=>
			opt.MapFrom(src=>src.ToUser.UserName)
			);







        }
	}
}

