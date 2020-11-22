using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Data
{
    public class Inquiry
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeCount { get; set; }
        public int PerformanceRating { get; set; }
        public int WorkLifeBalance { get; set; }
        public int EnviromentSatisfaction { get; set; }
        public int RelationshipSatisfaction { get; set; }
        public int JobSatisfaction { get; set; }
        public int StockLevelOption { get; set; }
        [ForeignKey("RequestingEmployeeId")]
        public Employee RequestingEmployee { get; set; }
        public string RequestingEmployeeId { get; set; }

    }
}
