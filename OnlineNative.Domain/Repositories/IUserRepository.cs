using OnlineNative.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

        bool CheckPassword(string userName, string password);
    }
}
