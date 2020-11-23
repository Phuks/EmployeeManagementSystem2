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
    public class EmployeeHistoryController : Controller
    {
        // Dependency Injection referencing one object and implying its dependencies
        private readonly IEmployeeHistoryRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeHistoryController(IEmployeeHistoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: EmployeeHistoryController
        public ActionResult Index()
        {
            var empHistory = _repo.FindAll().ToList();
            var model = _mapper.Map<List<EmployeeHistory>, List<EmployeeHistoryVM>>(empHistory);
            return View(model);
        }
        //[Authorize(Roles = "Employee")]
        // GET: EmployeeHistoryController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var empHistory = _repo.FindById(id);
            var model = _mapper.Map<EmployeeHistoryVM>(empHistory);
            return View(model);
        }

        // GET: EmployeeHistoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeHistoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeHistoryVM model)
        {
            try
            {
                // TODO: Adding insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var empHistory = _mapper.Map<EmployeeHistory>(model);

                var isSuccess = _repo.Create(empHistory);
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

        // GET: EmployeeHistoryController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var empHistory = _repo.FindById(id);
            var model = _mapper.Map<EmployeeHistoryVM>(empHistory);
            return View(model);
        }

        // POST: EmployeeHistoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeHistoryVM model)
        {
            try
            {
                // TODO: Adding update logic here
                if (!ModelState.IsValid)                // Validating the data
                {
                    return View(model);
                }
                var empHistory = _mapper.Map<EmployeeHistory>(model);           // Mapping from ViewModel to Data class and storing in variable
                var isSuccess = _repo.Update(empHistory);
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

        // GET: EmployeeHistoryController/Delete/5
        public ActionResult Delete(int id)
        {
            /*if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var empHistory = _repo.FindById(id);
            var model = _mapper.Map<EmployeeHistoryVM>(empHistory);
            return View(model);*/

            var empHistory = _repo.FindById(id);

            if (empHistory == null)
            {
                return NotFound();
            }

            var isSuccess = _repo.Delete(empHistory);

            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: EmployeeHistoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EmployeeHistoryVM model)
        {
            try
            {
                // TODO: Adding delete logic here
                var empHistory = _repo.FindById(id);

                if (empHistory == null)
                {
                    return NotFound();
                }

                var isSuccess = _repo.Delete(empHistory);

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
