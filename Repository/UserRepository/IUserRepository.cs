using System;
using Data.Entity;
using Repository.CommonRepository;

namespace Repository.UserRepository
{
    public interface IUserRepository : IGenaricRepository<User>
    {
        User GetUserByEmail(string email);
       
    }
}
