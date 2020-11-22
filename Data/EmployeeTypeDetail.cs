using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Data
{
    public class EmployeeTypeDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EducationField { get; set; }
        public int Education { get; set; }
        public string BusinessTravel { get; set; }
        public int DistanceFromHome { get; set; }
        public string JobRole { get; set; }
        public int JobInvolvement { get; set; }
        public int JobLevel { get; set; }
        public DateTime DateCreated { get; set; }
        
    }
}
