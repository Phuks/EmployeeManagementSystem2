using EmployeeManagementSystem2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Models
{
    public class InquiryVM
    {
        public int Id { get; set; }
        [Required]
        public int EmployeeCount { get; set; }
        [Required]
        public int PerformanceRating { get; set; }
        [Required]
        public int WorkLifeBalance { get; set; }
        [Required]
        public int EnviromentSatisfaction { get; set; }
        [Required]
        public int RelationshipSatisfaction { get; set; }
        [Required]
        public int JobSatisfaction { get; set; }
        [Required]
        public int StockLevelOption { get; set; }
        public Employee RequestingEmployee { get; set; }
        public string RequestingEmployeeId { get; set; }

    }
}
