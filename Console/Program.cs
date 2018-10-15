using Entity.DataBase;
using Poc.Implementation;
using Repository;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine($"{(new LoginService(new UserRepository(new DomainEntities())).Login("test", "1234") ? "Ok" : "Ko")}");
            System.Console.ReadLine();
        }
    }
}
