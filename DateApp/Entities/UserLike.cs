using System;
namespace Api.Entities
{
	public class UserLike
	{
       public int UserIdLike;
        public UserProfile? LikedByUser { get; set; }
        public UserProfile? LikedToUser { get; set; }
       
    }
}

