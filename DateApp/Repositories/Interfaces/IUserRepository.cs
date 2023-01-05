using System;
using Api.DTOs;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Repositories.Interfaces
{
	public interface IUserRepository
	{

        Task<UserProfile> GetUser(string username);
        //Task<UserProfile> GetUserByIdAsync(int id);
        void AddUserProfile(UserProfile user);
        //Task<UserProfile> GetUserByUsername(string username);


    }
}

