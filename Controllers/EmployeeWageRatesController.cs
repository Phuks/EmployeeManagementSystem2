using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagementSystem2.Data;
using EmployeeManagementSystem2.Interfaces;
using EmployeeManagementSystem2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem2.Controllers
{
    [Authorize(Roles = "Admin")]                 // Authorizing only Admin users that are logged in to avoid maliciousness  
    public class EmployeeWageRatesController : Controller
    {
        // Dependency Injection referencing one object and implying its dependencies
        private readonly IEmployeeWageRateRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeWageRatesController(IEmployeeWageRateRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: WageRateController
        public ActionResult Index()
        {
            var empWageRate = _repo.FindAll().ToList();
            var model = _mapper.Map<List<EmployeeWageRate>, List<EmployeeWageRateVM>>(empWageRate);
            return View(model);
        }
        //[Authorize(Roles = "Employee")]
        // GET: EmployeeWageRateController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var empWageRate = _repo.FindById(id);
            var model = _mapper.Map<EmployeeWageRateVM>(empWageRate);
            return View(model);
        }

        // GET: EmployeeWageRateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeWageRateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeWageRateVM model)
        {
            try
            {
                // TODO: Adding insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var empWageRate = _mapper.Map<EmployeeWageRate>(model);
                empWageRate.DateCreated = DateTime.Now;

                var isSuccess = _repo.Create(empWageRate);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "There is a fault somewhere...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "There is a fault somewhere...");
                return View(model);
            }
        }

        // GET: EmployeeWageRateController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var empWageRate = _repo.FindById(id);
            var model = _mapper.Map<EmployeeWageRateVM>(empWageRate);
            return View(model);
        }

        // POST: EmployeeWageRateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeWageRateVM model)
        {
            try
            {
                // TODO: Adding update logic here
                if (!ModelState.IsValid)                // Validating the data
                {
                    return View(model);
                }
                var empWageRate = _mapper.Map<EmployeeWageRate>(model);           // Mapping from ViewModel to Data class and storing in variable
                var isSuccess = _repo.Update(empWageRate);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "There is a fault somewhere...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "There is a fault somewhere...");
                return View(model);
            }
        }

        // GET: EmployeeWageRateController/Delete/5
        public ActionResult Delete(int id)
        {
            /*if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var empWageRate = _repo.FindById(id);
            var model = _mapper.Map<EmployeeWageRateVM>(empWageRate);
            return View(model);*/

            var empWageRate = _repo.FindById(id);

            if (empWageRate == null)
            {
                return NotFound();
            }

            var isSuccess = _repo.Delete(empWageRate);

            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: EmployeeWageRateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EmployeeWageRateVM model)
        {
            try
            {
                // TODO: Adding delete logic here
                var empWageRate = _repo.FindById(id);

                if (empWageRate == null)
                {
                    return NotFound();
                }

                var isSuccess = _repo.Delete(empWageRate);

                if (!isSuccess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
