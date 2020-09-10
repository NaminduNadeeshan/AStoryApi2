using System;
using Dto.Model;

namespace Services.AutherService
{
    public interface IAutherService
    {
        AutherDto AddAuther(AutherDto auther);
    }
}
