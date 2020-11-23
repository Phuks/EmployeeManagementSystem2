using EmployeeManagementSystem2.Data;
using EmployeeManagementSystem2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Repository
{
    public class EmployeeHistoryRepository : IEmployeeHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(EmployeeHistory entity)
        {
            _db.EmployeeHistories.Add(entity);
            return Save();
        }

        public bool Delete(EmployeeHistory entity)
        {
            _db.EmployeeHistories.Remove(entity);
            return Save();
        }

        public ICollection<EmployeeHistory> FindAll()
        {
            var empHistory = _db.EmployeeHistories.ToList();
            return empHistory;
        }

        public EmployeeHistory FindById(int id)
        {
            var empHistory = _db.EmployeeHistories.Find(id);
            return empHistory;
        }

        public ICollection<EmployeeHistory> GetEmployeesByEmployeeHistory(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            var exists = _db.EmployeeHistories.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(EmployeeHistory entity)
        {
            _db.EmployeeHistories.Update(entity);
            return Save();
        }
    }
}
