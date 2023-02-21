namespace DateApp.Functions.TransactionFunctions.Commands
{

    public class SetTransactionPandingConfirmCommand : IRequest<int>
    {

        public UserTransaction? UserTransaction { get; set; }

        public class SetTransactionExpires : IRequestHandler<SetTransactionPandingConfirmCommand, int>
        {
            private readonly AppDbContext _context;

            public SetTransactionExpires(AppDbContext context)
            {
                _context = context;
            }



            async Task<int> IRequestHandler<SetTransactionPandingConfirmCommand, int>.Handle(SetTransactionPandingConfirmCommand request, CancellationToken cancellationToken)
            {

                request.UserTransaction.PendingConfirm = true;

                _context.Update(request.UserTransaction);

                return await _context.SaveChangesAsync();
            }
        }

    }
}