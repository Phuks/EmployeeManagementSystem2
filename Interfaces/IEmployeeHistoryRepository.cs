﻿using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem2.Interfaces
{
    
    public interface IEmployeeHistoryRepository : IRepositoryBase<EmployeeHistory>
    {
        ICollection<EmployeeHistory> GetEmployeesByEmployeeHistory(int id);
    }
}
