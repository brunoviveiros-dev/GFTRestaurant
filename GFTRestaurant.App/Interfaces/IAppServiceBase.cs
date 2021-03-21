using System.Collections.Generic;

namespace GFTRestaurant.App.Interfaces
{
    public interface IAppServiceBase<T> where T : class
    {
        T Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        void DeleteAll();
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
