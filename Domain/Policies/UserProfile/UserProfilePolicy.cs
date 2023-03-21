using Microsoft.AspNetCore.Authorization;
using Domain.Interfaces.Repositories;
using System;
using Microsoft.EntityFrameworkCore;

namespace Domain.Policies.UserProfile
{


 
        public class RequirementHandler : AuthorizationHandler<UserProfileRequirement>
        {
            private readonly IUserProfileRepository _userProfileRepository;

            public RequirementHandler(IUserProfileRepository userProfileRepository)
            {

                _userProfileRepository = userProfileRepository;
            }

            protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserProfileRequirement requirement)
            {
                var currentUserName = context.User.Identity.Name;

                var result = await _userProfileRepository.getUserProfileByName(currentUserName);

                if (result != null) context.Succeed(requirement);

                await Task.CompletedTask;
            }
        }


        public class UserProfileRequirement : IAuthorizationRequirement
        {

        }
    }





