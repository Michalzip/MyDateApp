namespace DateApp.Functions.TransactionFunctions.Commands
{


    public class SetTransactionSuccessCommand : IRequest<int>
    {

        public UserTransaction? UserTransaction { get; set; }

        public class SetTransactionExpires : IRequestHandler<SetTransactionSuccessCommand, int>
        {
            private readonly AppDbContext _context;

            public SetTransactionExpires(AppDbContext context)
            {
                _context = context;
            }



            async Task<int> IRequestHandler<SetTransactionSuccessCommand, int>.Handle(SetTransactionSuccessCommand request, CancellationToken cancellationToken)
            {

                request.UserTransaction.Success = true;

                request.UserTransaction.PendingConfirm = false;

                _context.Update(request.UserTransaction);

                return await _context.SaveChangesAsync();
            }
        }

    }
}