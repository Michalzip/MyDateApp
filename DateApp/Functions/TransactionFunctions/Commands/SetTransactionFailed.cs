namespace DateApp.Functions.TransactionFunctions.Commands
{
    public class SetTransactionFailed
    {

    }

    public class SetTransactionFailedCommand : IRequest<int>
    {

        public UserTransaction? UserTransaction { get; set; }

        public class SetTransactionExpires : IRequestHandler<SetTransactionFailedCommand, int>
        {
            private readonly AppDbContext _context;

            public SetTransactionExpires(AppDbContext context)
            {
                _context = context;
            }



            async Task<int> IRequestHandler<SetTransactionFailedCommand, int>.Handle(SetTransactionFailedCommand request, CancellationToken cancellationToken)
            {

                request.UserTransaction.Failed = true;
                request.UserTransaction.PendingConfirm = false;

                _context.Update(request.UserTransaction);
                return await _context.SaveChangesAsync();
            }
        }

    }
}