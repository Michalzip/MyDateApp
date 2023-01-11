using System;
using Api.DTOs;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Repositories.Interfaces
{
	public interface IUserRepository
	{

        Task<UserProfile> GetUser(string username);
        void AddUserProfile(UserProfile user);


    }
}

