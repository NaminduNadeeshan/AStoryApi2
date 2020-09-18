using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entity;
using Repository.CommonRepository;

namespace Repository.UserRepository
{
    public class UserRepository : GenaricRepository<User>, IUserRepository
    {
        private readonly AStoryDatabaseContext _context;

        public UserRepository(AStoryDatabaseContext context): base(context)
        {
            _context = context;
        }

        public List<User> GetUserByEmail(string email)
        {
            var getUser = _context.Users.Where<User>(user => user.Email == email).ToList<User>();

            return getUser;
        }

      
    }
}
