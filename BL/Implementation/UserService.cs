using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BL.Abstraction;
using DAL.DataModel;
using DAL.Repository;

namespace BL.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }
    }
}
