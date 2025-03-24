using Demo.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Route.Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
