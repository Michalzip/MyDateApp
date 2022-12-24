using System;
using App.Models;
using AutoMapper;
using App.DTOs;
using System.Linq;
namespace App.Helpers
{
	public class AutoMapperProfiles: Profile
    {
		public AutoMapperProfiles()
		{
			CreateMap<RegisterDto, ApplicationUser>();
		}
	}
}

