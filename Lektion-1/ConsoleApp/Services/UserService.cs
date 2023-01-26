using ConsoleApp.Abstractions;
using ConsoleApp.Models;

namespace ConsoleApp.Services
{
    public class UserService : GenericService<UserModel>
    {
        public override void Create(UserModel type)
        {
            base.Create(type);
        }
    }
}
