using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Models
{
    public class EmployeeHistoryVM
    {
        public int Id { get; set; }
        [Required]
        public int NumCompaniesWorked { get; set; }
        [Required]
        public int YearsAtCompany { get; set; }
        [Required]
        public int YearsInCurrentRole { get; set; }
        [Required]
        public int YearsSinceLastPromotion { get; set; }
        [Required]
        public int YearsWithCurrManager { get; set; }
        [Required]
        public int TotalWorkingYears { get; set; }
        [Required]
        public int TrainingTimesLastYear { get; set; }
        public EmployeeVM RequestingEmployee { get; set; }
        public string RequestingEmployeeId { get; set; }
        public EmployeeTypeDetailVM EmployeeType { get; set; }
        public int EmployeeTypeId { get; set; }
    }
}
