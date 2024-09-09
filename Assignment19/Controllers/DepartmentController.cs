using BLL.Respositories;
using DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _repository;
        private readonly IWebHostEnvironment env;

        public DepartmentController(IDepartmentRepository departmentRepository, IWebHostEnvironment env)
        {
            _repository = departmentRepository;
            this.env = env;
        }
        public IActionResult Index()
        {
            var departments = _repository.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var count = _repository.Add(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(department);
        }

        [HttpGet]
        public IActionResult Details(int? id, string viewName = nameof(Details))
        {
            if(!id.HasValue)
            {
                return BadRequest();
            }

            var department = _repository.GetById(id.Value);
            if (department == null)
            {
                return NotFound();
            }

            return View(viewName, department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return Details(id, nameof(Edit));
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(department);
            }

            try
            {
                _repository.Update(department);
                return RedirectToAction(nameof(Index));
            }
            catch(System.Exception ex)
            {
                if(env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error occured during update");
                }

                return View(department);
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, nameof(Delete));
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            try
            {
                _repository.Delete(department);
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

                return View(department);
            }
        }
    }
}
