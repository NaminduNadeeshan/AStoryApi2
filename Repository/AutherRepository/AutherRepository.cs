using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entity;
using Repository.CommonRepository;

namespace Repository.AutherRepository
{
    public class AutherRepository: GenaricRepository<Auther>, IAutherRepository
    {
        private readonly AStoryDatabaseContext _context;
        public AutherRepository(AStoryDatabaseContext context):base(context)
        {
            _context = context;
        }

        public List<Auther> AutherByEmail(string email)
        {
            return _context.Authers.Where(auther => auther.Email == email).ToList();
        }
    }
}
