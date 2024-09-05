using BLL.Respositories;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _repository = departmentRepository;
        }
        public IActionResult Index()
        {
            _repository.GetAll();
            return View();
        }
    }
}
