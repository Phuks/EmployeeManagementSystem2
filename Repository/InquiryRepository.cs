using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem2.Data;
using EmployeeManagementSystem2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Repository
{
    public class InquiryRepository : IInquiryRespository
    {
        private readonly ApplicationDbContext _db;

        public InquiryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Inquiry entity)
        {
            _db.Inquiries.Add(entity);
            return Save();
        }

        public bool Delete(Inquiry entity)
        {
            _db.Inquiries.Add(entity);
            return Save();
        }

        public ICollection<Inquiry> FindAll()
        {
            var empInquiry = _db.Inquiries.ToList();
            return empInquiry;
        }

        public Inquiry FindById(int id)
        {
            var empInquiry = _db.Inquiries.Find(id);
            return empInquiry;
        }

        public bool isExists(int id)
        {
            var exists = _db.Inquiries.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Inquiry entity)
        {
            _db.Inquiries.Update(entity);
            return Save();
        }
    }
}
