using Entity.DataBase;
using Poc;
using System.Linq;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DomainEntities _domainDbContext;
        public UserRepository(DomainEntities domainDbContext)
        {
            _domainDbContext = domainDbContext;
        }

        public bool Exist(string login, string password)
        {
            return _domainDbContext.User.Any(_ => _.Login == login && _.Password == password);
        }
    }
}
