using System;
using System.Collections.Generic;
using Data.Entity;
using Repository.CommonRepository;

namespace Repository.AutherRepository
{
    public interface IAutherRepository: IGenaricRepository<Auther>
    {
        List<Auther> AutherByEmail(string email);
    }
}
