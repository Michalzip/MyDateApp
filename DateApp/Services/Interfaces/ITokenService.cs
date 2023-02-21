namespace App.Interfaces
{


    public interface CreateToken
    {
        public Task<string> CreateToken(ApplicationUser user);
    }

    public interface ITokenService : CreateToken
    {
    }
}

