using AutoMapper;
using EmployeeManagementSystem2.Data;
using EmployeeManagementSystem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Mappings
{
    public class Maps : Profile
    {
        public Maps()             // Constructor to create maps to exist in application
        {
            CreateMap<EmployeeTypeDetail, EmployeeTypeDetailVM>().ReverseMap();
            CreateMap<EmployeeHistory, EmployeeHistoryVM>().ReverseMap();
            CreateMap<EmployeeWageRate, EmployeeWageRateVM>().ReverseMap();
            CreateMap<Inquiry, InquiryVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }

    }
}
