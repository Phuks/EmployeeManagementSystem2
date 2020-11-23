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
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem2.Controllers
{
     
    public class EmployeeTypeDetailController : Controller
    {
        // Dependency Injection referencing one object and implying its dependencies
        private readonly IEmployeeTypeDetailRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeTypeDetailController(IEmployeeTypeDetailRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [Authorize(Roles = "Admin")]                 // Authorizing only Admin users that are logged in to avoid maliciousness 

        // GET: EmployeeTypeDetailController
        public ActionResult Index()
        {
            var empTypeDetail = _repo.FindAll().ToList();
            var model = _mapper.Map<List<EmployeeTypeDetail>, List<EmployeeTypeDetailVM>>(empTypeDetail);
            return View(model);
        }
        //[Authorize(Roles = "Employee")]
        // GET: EmployeeTypeDetailController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var empTypeDetail = _repo.FindById(id);
            var model = _mapper.Map<EmployeeTypeDetailVM>(empTypeDetail);
            return View(model);
        }
        [Authorize(Roles = "Admin, Employee")]
        // GET: EmployeeTypeDetailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeTypeDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeTypeDetailVM model)
        {
            try
            {
                // TODO: Adding insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var empTypeDetail = _mapper.Map<EmployeeTypeDetail>(model);
                empTypeDetail.DateCreated = DateTime.Now;

                var isSuccess = _repo.Create(empTypeDetail);
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

        // GET: EmployeeTypeDetailController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var empTypeDetail = _repo.FindById(id);
            var model = _mapper.Map<EmployeeTypeDetailVM>(empTypeDetail);
            return View(model);
        }

        // POST: EmployeeTypeDetailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeTypeDetailVM model)
        {
            try
            {
                // TODO: Adding update logic here
                if (!ModelState.IsValid)                // Validating the data
                {
                    return View(model);
                }
                var empTypeDetail = _mapper.Map<EmployeeTypeDetail>(model);           // Mapping from ViewModel to Data class and storing in variable
                var isSuccess = _repo.Update(empTypeDetail);
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
        [Authorize(Roles = "Admin")]                 // Authorizing only Admin users that are logged in to avoid maliciousness 
        // GET: EmployeeTypeDetailController/Delete/5
        public ActionResult Delete(int id)
        {
            /*if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var empTypeDetail = _repo.FindById(id);
            var model = _mapper.Map<EmployeeTypeDetailVM>(empTypeDetail);
            return View(model);*/

            var empTypeDetail = _repo.FindById(id);

            if (empTypeDetail == null)
            {
                return NotFound();
            }

            var isSuccess = _repo.Delete(empTypeDetail);

            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: EmployeeTypeDetailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EmployeeTypeDetailVM model)
        {
            try
            {
                // TODO: Adding delete logic here
                var empTypeDetail = _repo.FindById(id);

                if (empTypeDetail == null)
                {
                    return NotFound();
                }

                var isSuccess = _repo.Delete(empTypeDetail);

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
