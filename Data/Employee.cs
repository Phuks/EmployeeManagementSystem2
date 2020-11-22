using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Data
{
    public class Employee : IdentityUser
    {
        //public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int EmployeeNumber { get; set; }
        [Column(TypeName = "char(5)")]
        public string Attrition { get; set; }
        public int Age { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Gender { get; set; }
        [Column(TypeName = "char(10)")]
        public char Over18 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string MaritalStatus { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string JobRole { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Department { get; set; }
        

    }
}
