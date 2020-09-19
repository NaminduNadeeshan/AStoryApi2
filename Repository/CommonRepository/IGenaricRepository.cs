using System;
using System.Collections.Generic;
using Dto.Model;

namespace Repository.CommonRepository
{
    public interface IGenaricRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int Id);

        T Insert(T item);

        T Update(T item);

        int Delete(int id);

        void Save();
    }
}
