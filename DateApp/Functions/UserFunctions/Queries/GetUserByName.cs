using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateApp.Functions.UserFunctions.Queries
{


    public class GetUserByNameQuery : IRequest<UserProfile>
    {
        public string? userName { get; set; }
        public class GetUserByName : IRequestHandler<GetUserByNameQuery, UserProfile>
        {
            private readonly AppDbContext _context;

            public GetUserByName(AppDbContext context)
            {
                _context = context;

            }

            async Task<UserProfile> IRequestHandler<GetUserByNameQuery, UserProfile>.Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
            {
                var userProfile = await _context.UserProfiles.Where(u => u.UserName == request.userName).FirstOrDefaultAsync();

                if (userProfile == null) return null;

                return userProfile;


            }


        }


    }
}