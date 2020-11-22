using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Data
{
    public class EmployeeHistory
    {
        [Key]
        public int Id { get; set; }
        public int NumCompaniesWorked { get; set; }
        public int YearsAtCompany { get; set; }
        public int YearsInCurrentRole { get; set; }
        public int YearsSinceLastPromotion { get; set; }
        public int YearsWithCurrManager { get; set; }
        public int TotalWorkingYears { get; set; }
        public int TrainingTimesLastYear { get; set; }
        [ForeignKey("RequestingEmployeeId")]
        public Employee RequestingEmployee { get; set; }
        public string RequestingEmployeeId { get; set; }
        [ForeignKey("EmployeeTypeId")]
        public EmployeeTypeDetail EmployeeType { get; set; }
        public int EmployeeTypeId { get; set; }
    }
}
