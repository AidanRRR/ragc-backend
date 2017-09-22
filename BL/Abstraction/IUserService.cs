using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModel;

namespace BL.Abstraction
{
    public interface IUserService
    {
        Task<bool> AddUser(User user);
    }
}
