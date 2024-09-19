using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly IWebHostEnvironment env;

        public EmployeeController(IEmployeeRepository employeeRepository, IWebHostEnvironment env)
        {
            _repository = employeeRepository;
            this.env = env;
        }
        public IActionResult Index()
        {
            var Employees = _repository.GetAll();
            return View(Employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                var count = _repository.Add(Employee);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(Employee);
        }

        [HttpGet]
        public IActionResult Details(int? id, string viewName = nameof(Details))
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var Employee = _repository.GetById(id.Value);
            if (Employee == null)
            {
                return NotFound();
            }

            return View(viewName, Employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return Details(id, nameof(Edit));
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, Employee Employee)
        {
            if (id != Employee.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(Employee);
            }

            try
            {
                _repository.Update(Employee);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                if (env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error occured during update");
                }

                return View(Employee);
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, nameof(Delete));
        }

        [HttpPost]
        public IActionResult Delete(Employee Employee)
        {
            try
            {
                _repository.Delete(Employee);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                if (env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error occured during delete");
                }

                return View(Employee);
            }
        }
    }
}
