using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Data
{
    public class EmployeeWageRate
    {
        [Key]
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
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeTypeId")]
        public EmployeeTypeDetail EmployeeType { get; set; }
        public int EmployeeTypeId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
