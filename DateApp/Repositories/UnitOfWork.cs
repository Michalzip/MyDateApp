using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repositories.Interfaces;
using App.Db;
using Api.Repositories;
using MediatR;

namespace Api.Repository
{


    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public UnitOfWork(AppDbContext context, IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _context = context;

        }

        public IUserRepository UserRepository => new UserRepository(_context, _mapper);
        public IMessageRepository MessageRepository => new MessageRepository(_context);
        public ILikeRepository LikeRepository => new LikeRepository(_context);


        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }


}