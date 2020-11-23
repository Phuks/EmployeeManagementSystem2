using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagementSystem2.Data;
using EmployeeManagementSystem2.Interfaces;
using EmployeeManagementSystem2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem2.Controllers
{
    [Authorize(Roles = "Admin")]                 // Authorizing only Admin users that are logged in to avoid maliciousness
    public class EmployeeWageRateController : Controller
    {
        // Dependency Injection referencing one object and implying its dependencies
        private readonly IEmployeeTypeDetailRepository _empjobinforepo;
        private readonly IEmployeeWageRateRepository _empwagesrepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;

        public EmployeeWageRateController(
            IEmployeeTypeDetailRepository empjobinforepo,
            IEmployeeWageRateRepository empwagesrepo,
            IMapper mapper,
            UserManager<Employee> userManager
        )
        {
            _empjobinforepo = empjobinforepo;
            _empwagesrepo = empwagesrepo;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: EmployeeWageRateController
        public ActionResult Index()
        {
            var empJobInfo = _empjobinforepo.FindAll().ToList();
            var mappedEmployeeJobInfo = _mapper.Map<List<EmployeeTypeDetail>, List<EmployeeTypeDetailVM>>(empJobInfo); //Loading the model to be a list of EmployeeJobInfo
            var model = new CreateEmployeeWageRateVM
            {
                EmployeeTypes = mappedEmployeeJobInfo,
                NumberUpdated = 0
            };
            return View(model);
        }

        // Creating a custom action
        public ActionResult SetWage(int id)
        {
            var empjobinfo = _empjobinforepo.FindById(id);
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
            foreach (var emp in employees)
            {
                if (_empwagesrepo.CheckAllocation(id, emp.Id))
                    continue;

                var allocation = new EmployeeWageRateVM
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = emp.Id,
                    EmployeeTypeId = id,
                    MonthlyIncome = int.MaxValue,
                    DailyRate = int.MaxValue,
                    HourlyRate = int.MaxValue,
                    Overtime = string.Empty,
                    PercentSalaryHike = int.MaxValue,
                    Period = DateTime.Now.Year,

                };
                var empwages = _mapper.Map<EmployeeWageRate>(allocation);
                _empwagesrepo.Create(empwages);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EmployeeWageRateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeWageRateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeWageRateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeWageRateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeWageRateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeWageRateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeWageRateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
