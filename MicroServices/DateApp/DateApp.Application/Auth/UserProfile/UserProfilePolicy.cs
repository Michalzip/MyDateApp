
// using IdentityServer.Application.Services.Interfaces;

// namespace DateApp.Application.Auth.UserProfile
// {

//     public class RequirementHandler : AuthorizationHandler<UserProfilePolicy>
//     {
//         private readonly IDentityUserService _userIdentitieService;

//         public RequirementHandler(IDentityUserService userIdentitieService)
//         {

//             _userIdentitieService = userIdentitieService;
//         }

//         protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserProfilePolicy requirement)
//         {
//             var currentUserName = context.User.Identity.Name;

//             var result = await _userIdentitieService.GetIdentityUserByName(currentUserName);

//             if (result != null) context.Succeed(requirement);

//             await Task.CompletedTask;
//         }
//     }


//     public class UserProfilePolicy : IAuthorizationRequirement
//     {

//     }

// }