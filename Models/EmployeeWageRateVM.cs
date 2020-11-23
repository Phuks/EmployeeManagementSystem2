using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Models
{
    public class EmployeeWageRateVM
    {
        public int Id { get; set; }
        [Required]
        public int MonthlyIncome { get; set; }
        [Required]
        public int MonthlyRate { get; set; }
        [Required]
        public int DailyRate { get; set; }
        [Required]
        public int HourlyRate { get; set; }
        [Required]
        public int StandardHours { get; set; }
        [Required]
        public string Overtime { get; set; }
        [Required]
        public int PercentSalaryHike { get; set; }
        public EmployeeVM Employee { get; set; }
        public string EmployeeId { get; set; }
        public EmployeeTypeDetailVM EmployeeType { get; set; }
        public int EmployeeTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }

    }

    public class CreateEmployeeWageRateVM
    {
        public int NumberUpdated { get; set; }
        public List<EmployeeTypeDetailVM> EmployeeTypes { get; set; }
    }
}
