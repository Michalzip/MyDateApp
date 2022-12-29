using System;
using Api.DTOs;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Repositories.Interfaces
{
	public interface IUserRepo
	{

        Task<UserProfile> GetUserByName(string userName);
        Task<UserProfile> AddUserProfile(UserProfileDto model);

    }
}

