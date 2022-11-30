using System;
using System.Security.Cryptography;
using App.Models;
using Microsoft.AspNetCore.Identity;

namespace App.Services
{
	public class HashPassword
	{

       
        public static String CreatePasswordHash(UserRegisterModel model)
		{
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                 byte[] passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(model.Password));
               string passwordHashToString= Convert.ToBase64String(passwordHash);
                return passwordHashToString;
            }
        }
	}
}

