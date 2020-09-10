using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository.CommonRepository
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {

        private readonly AStoryDatabaseContext _context;
        private readonly DbSet<T> _table;

        public GenaricRepository(AStoryDatabaseContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public int Delete(int item)
        {
            try
            {
                T existing = _table.Find(item);
                _table.Remove(existing);

                return item;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public IEnumerable<T> GetAll(int skip, int take)
        {
            return _table.Skip(skip).Take(take).ToList();
        }

        public T GetById(int Id)
        {
            return _table.Find(Id);
        }

        public T Insert(T item)
        {
            try
            {
                _table.Add(item);
                Save();
                return item;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public T Update(T item)
        {
            try
            {
                _table.Attach(item);
                _context.Entry(item).State = EntityState.Modified;
                Save();
                return item;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
