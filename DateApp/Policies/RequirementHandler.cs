
using App.Db;


namespace Api.Policy
{
    public class RequirementHandler : AuthorizationHandler<UserProfileRequirement>
    {
        private readonly AppDbContext _context;

        public RequirementHandler(AppDbContext context)
        {

            _context = context;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserProfileRequirement requirement)
        {
            var currentUserName = context.User.Identity.Name;

            var result =  _context.UserProfiles.Where(u => u.UserName == currentUserName).FirstOrDefault();

            if (result != null) context.Succeed(requirement);
        


          
        }
    }
}

