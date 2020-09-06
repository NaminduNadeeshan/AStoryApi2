using System;
using Microsoft.AspNetCore.Mvc;

namespace Repository.Common
{
    public class CommonController<T> : Controller, ICommonController<T>
    {

        public T DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("getAll")]
        public T GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public T UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
