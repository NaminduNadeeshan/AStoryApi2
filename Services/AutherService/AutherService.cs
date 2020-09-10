using System;
using Data.Entity;
using Dto.Model;
using Microsoft.EntityFrameworkCore.Internal;
using Repository.AutherRepository;
using Repository.CommonRepository;

namespace Services.AutherService
{
    public class AutherService : IAutherService
    {
        private readonly IGenaricRepository<Auther> _commonContext;
        private readonly IAutherRepository _autherRepository;
        public AutherService(IGenaricRepository<Auther> commonContext, IAutherRepository autherRepository)
        {
            _commonContext = commonContext;
            _autherRepository = autherRepository;
        }

        public AutherDto AddAuther(AutherDto auther)
        {

            var existingUser = _autherRepository.AutherByEmail(auther.Email);
            if (!existingUser.Any())
            {
                var insertObject = new Auther
                {
                    Address = auther.Address,
                    AutherId = auther.AutherId,
                    Email = auther.Email,
                    FirstName = auther.FirstName,
                    LastName = auther.LastName,
                    PhoneNumber = auther.PhoneNumber,
                    ProfilePictureUrl = auther.ProfilePictureUrl,
                };

                var responseObject = _commonContext.Insert(insertObject);

                var returnObject = new AutherDto
                {
                    Address = responseObject.Address,
                    AutherId = responseObject.AutherId,
                    Email = responseObject.Email,
                    FirstName = responseObject.FirstName,
                    LastName = responseObject.LastName,
                    PhoneNumber = responseObject.PhoneNumber,
                    ProfilePictureUrl = responseObject.ProfilePictureUrl
                };

                return returnObject;
            } else
            {
                var returnObject = new AutherDto { };
                foreach(Auther authurs in existingUser)
                {
                    returnObject = new AutherDto
                    {
                        Address = authurs.Address,
                        AutherId = authurs.AutherId,
                        Email = authurs.Email,
                        FirstName = authurs.FirstName,
                        LastName = authurs.LastName,
                        PhoneNumber = authurs.PhoneNumber,
                        ProfilePictureUrl = authurs.ProfilePictureUrl
                    };
                }

                return returnObject;
            }
        }
    }
}
