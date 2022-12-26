﻿using System;
using App.Models;
using AutoMapper;
using App.DTOs;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer;

using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.EntityFrameworkCore;
namespace App.Helpers
{
	public class AutoMapperProfiles: Profile
    {
		public AutoMapperProfiles()
		{
			CreateMap<RegisterDto, IdentityUser>();
		}
	}
}

