using EmployeeManagementSystem2.Data;
using EmployeeManagementSystem2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Repository
{
    public class EmployeeTypeDetailRepository : IEmployeeTypeDetailRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeTypeDetailRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(EmployeeTypeDetail entity)
        {
            _db.EmployeeTypeDetails.Add(entity);
            return Save();
        }

        public bool Delete(EmployeeTypeDetail entity)
        {
            _db.EmployeeTypeDetails.Remove(entity);
            return Save();
        }

        public ICollection<EmployeeTypeDetail> FindAll()
        {
            return _db.EmployeeTypeDetails.ToList();
        }

        public EmployeeTypeDetail FindById(int id)
        {
            var empType = _db.EmployeeTypeDetails.Find(id);
            return empType;
        }

        public ICollection<EmployeeTypeDetail> GetEmployeesByEmployeeTypeDetail(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            var exists = _db.EmployeeTypeDetails.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(EmployeeTypeDetail entity)
        {
            _db.EmployeeTypeDetails.Update(entity);
            return Save();
        }
    }
}
