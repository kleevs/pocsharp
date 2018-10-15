namespace Poc.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Login(string login, string password)
        {
            return _userRepository.Exist(login, password);
        }
    }
}
