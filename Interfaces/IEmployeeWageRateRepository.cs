﻿using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Interfaces
{
    public interface IEmployeeWageRateRepository : IRepositoryBase<EmployeeWageRate>
    {
        ICollection<EmployeeWageRate> GetEmployeesByEmployeeWageRate(int id);

        bool CheckAllocation(int emptypeid, string employeeid);

        ICollection<EmployeeWageRate> GetEmployeeWageRateByEmployee(string id);

    }
}