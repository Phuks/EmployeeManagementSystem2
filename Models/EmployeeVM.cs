using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Models
{
    public class EmployeeVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Required]
        public int EmployeeNumber { get; set; }
        [Required]
        public string Attrition { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public char Over18 { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public string JobRole { get; set; }
        [Required]
        public string Department { get; set; }
    }
}
