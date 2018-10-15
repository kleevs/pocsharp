namespace Poc
{
    public interface IUserRepository
    {
        bool Exist(string login, string password);
    }
}
