namespace DateApp.Functions.TransactionFunctions.Commands
{
    public class SetTransactionExpiresCommand : IRequest<int>
    {

        public UserTransaction? UserTransaction { get; set; }

        public class SetTransactionExpires : IRequestHandler<SetTransactionExpiresCommand, int>
        {
            private readonly AppDbContext _context;

            public SetTransactionExpires(AppDbContext context)
            {
                _context = context;
            }



            async Task<int> IRequestHandler<SetTransactionExpiresCommand, int>.Handle(SetTransactionExpiresCommand request, CancellationToken cancellationToken)
            {

                request.UserTransaction.Expires = true;

                request.UserTransaction.PendingConfirm = false;

                _context.Update(request.UserTransaction);

                return await _context.SaveChangesAsync();
            }
        }

    }
}