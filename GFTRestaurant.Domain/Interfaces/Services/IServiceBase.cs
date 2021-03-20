using System;
using System.Collections.Generic;

namespace GFTRestaurant.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        IEnumerable<T> GetAll();
        T GetById(Int64 id);
    }
}
