using System;
using System.Collections.Generic;
using Data.Entity;
using Repository.CommonRepository;

namespace Repository.UserRepository
{
    public interface IUserRepository : IGenaricRepository<User>
    {
        List<User> GetUserByEmail(string email);
       
    }
}
