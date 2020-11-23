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
        [Display(Name = "Education Field")]
        public string EducationField { get; set; }
        [Display(Name = "Education")]
        public int Education { get; set; }
        [Display(Name = "Business Travel")]
        public string BusinessTravel { get; set; }
        [Display(Name = "Distance")]
        public int DistanceFromHome { get; set; }
        [Display(Name = "Job Role")]
        public string JobRole { get; set; }
        [Display(Name = "Job Involvement")]
        public int JobInvolvement { get; set; }
        [Display(Name = "Job Level")]
        public int JobLevel { get; set; }
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }
        
    }
}
