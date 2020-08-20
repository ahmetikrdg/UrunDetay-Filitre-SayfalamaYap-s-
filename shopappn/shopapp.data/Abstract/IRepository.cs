using System.Collections.Generic;

namespace shopapp.data.Abstract
{
    public interface IRepository<T>
    {//Ordera yada producta bağlı değil biz ona hangi clası gönderirsek o ona göre davranır
         T GetById(int id);
         List<T> GetAll();
         void Create(T entity);
         void Update(T entity);
         void Delete(T entity);
    }
}