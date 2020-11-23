using EmployeeManagementSystem2.Data;
using EmployeeManagementSystem2.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Repository
{
    public class EmployeeWageRateRepository : IEmployeeWageRateRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeWageRateRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CheckAllocation(int emptypeid, string employeeid)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .Where(q => q.EmployeeId == employeeid && q.EmployeeTypeId == emptypeid && q.MonthlyIncome == period)
                .Any();
        }

        public bool Create(EmployeeWageRate entity)
        {
            _db.EmployeeWageRates.Add(entity);
            return Save();
        }

        public bool Delete(EmployeeWageRate entity)
        {
            _db.EmployeeWageRates.Remove(entity);
            return Save();
        }

        public ICollection<EmployeeWageRate> FindAll() // REVIEW
        {
            var empWages = _db.EmployeeWageRates.Include(q => q.EmployeeId).ToList();
            return empWages;
            
        }

        public EmployeeWageRate FindById(int id)
        {
            var empWages = _db.EmployeeWageRates.Find();
            return empWages;
        }

        public ICollection<EmployeeWageRate> GetEmployeesByEmployeeWageRate(int id)
        {
            /*var monthlyincome = int.MaxValue;
            return FindAll()
                .Where(q => q.EmployeeId == id && q.MonthlyIncome == monthlyincome)
                .ToList();*/
            throw new NotImplementedException();
        }

        public ICollection<EmployeeWageRate> GetEmployeeWageRateByEmployee(string id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            var exists = _db.EmployeeWageRates.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(EmployeeWageRate entity)
        {
            _db.EmployeeWageRates.Update(entity);
            return Save();
        }
    }
}
