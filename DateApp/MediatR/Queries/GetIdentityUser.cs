using System;
using Api.DTOs;
using Api.Entities;
using App.Db;

namespace Api.MediatR.Queries
{

    public class GetIdentityUserQueryHandler : IRequestHandler<UserProfileDto, UserProfile>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _context;

        public GetIdentityUserQueryHandler(UserManager<IdentityUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }



        async Task<UserProfile> IRequestHandler<UserProfileDto, UserProfile>.Handle(UserProfileDto request, CancellationToken cancellationToken)
        {
            var identityUser = await _userManager.FindByNameAsync(request.UserName);

            if (identityUser == null) return new UserProfile { };
            
            var user = new UserProfile
            {
                UserId = identityUser.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = identityUser.UserName,
                PhotoUrl = request.PhotoUrl,


            };

            _context.UserProfiles.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }



        //Musisz zmapować z IdentytyUser na IdentityUserDto i wysłać to
        //    do mediatr, ponieważ tego oczekuje twój program obsługi






    }
}

