using GFTRestaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFTRestaurant.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DatabaseContext _databaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public void Add(T obj)
        {
            _databaseContext.Set<T>().Add(obj);
            _databaseContext.SaveChanges();
        }

        public void Delete(T obj)
        {
            _databaseContext.Set<T>().Remove(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _databaseContext.Set<T>().ToList();
        }

        public void Update(T obj)
        {
            _databaseContext.SaveChanges();
        }

        public T GetById(Int64 Id)
        {
            return _databaseContext.Set<T>().Find(Id);
        }

    }
}
