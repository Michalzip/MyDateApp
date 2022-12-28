using System;
using Api.Entities;

namespace Api.DTOs
{
	public class UserProfileDto : IRequest<UserProfile>
    {
        public string? UserId;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? PhotoUrl { get; set; }
 
    }
}

