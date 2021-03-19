using System;
using System.Collections.Generic;
using System.Text;

namespace GFTRestaurant.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        IEnumerable<T> GetAll();
        T GetById(Int64 id);
    }
}
