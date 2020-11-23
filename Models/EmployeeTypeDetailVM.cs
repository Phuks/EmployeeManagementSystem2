using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Models
{
    public class EmployeeTypeDetailVM
    {
        public int Id { get; set; }
        [Required]
        public string EducationField { get; set; }
        [Required]
        public int Education { get; set; }
        [Required]
        public string BusinessTravel { get; set; }
        [Required]
        public int DistanceFromHome { get; set; }
        [Required]
        public string JobRole { get; set; }
        [Required]
        public int JobInvolvement { get; set; }
        [Required]
        public int JobLevel { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
