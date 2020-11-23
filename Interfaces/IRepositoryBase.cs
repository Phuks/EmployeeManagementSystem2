using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IRepositoryBase<T> where T : class              //Creating a generic interface that can pass any class and perform operations outlined CRUD
    {
        ICollection<T> FindAll();
        T FindById(int id);
        bool isExists(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();

    }
}
