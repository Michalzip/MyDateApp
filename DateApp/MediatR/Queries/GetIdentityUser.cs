using System;
using Api.DTOs;
using Api.Entities;
using App.Db;
using Server.Repository;
using Server.Repository.interfaces;

namespace Api.MediatR.Queries
{

    public class GetIdentityUserQueryHandler : IRequestHandler<UserProfileDto, UserProfile>
    {
        private readonly IIdentityUserRepo _identityUserRepo;
        private readonly AppDbContext _context;

        public GetIdentityUserQueryHandler(IIdentityUserRepo identityUserRepo, AppDbContext context)
        {
            _identityUserRepo = identityUserRepo;
            _context = context;
        }



        async Task<UserProfile> IRequestHandler<UserProfileDto, UserProfile>.Handle(UserProfileDto request, CancellationToken cancellationToken)
        {

            var identityUser = await _identityUserRepo.GetIdentityUserByName(request.UserName);

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



  





    }
}

