using Demo.BusinessLogic.DataTransferObject.Departments;
using Demo.BusinessLogic.DataTransferObject.Employees;
using Demo.BusinessLogic.Services.DepartmentService;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Repositories.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Route.Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
      
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger, IWebHostEnvironment env)
        {
            _employeeService = employeeService;
            _logger = logger;
            _env = env;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();
          
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            string message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employeeDto);
                    return RedirectToAction(nameof(Index));
                }
                message = "Employee Can Not Created";
                ModelState.AddModelError(string.Empty, message);
                return View(employeeDto);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                if (_env.IsDevelopment())
                {
                    message = ex.Message;
                    return View(employeeDto);
                }
                else
                {
                    message = "Employee Can Not Created";
                    return View("Error", message);
                }

            }

        }
        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id == null)
                return BadRequest();
            var employee = _employeeService.GetById(id.Value);
            if (employee is null)
                return NotFound();

            return View(viewName, employee);
        }
        [HttpGet]
        //public IActionResult Update(int? id)
        //{
        //    if (id is null)
        //        return BadRequest();//400
        //    var employee = _employeeService.GetById(id.Value);
        //    if (employee is null)
        //        return NotFound();
        //    var UodateDto = new UpdatedEmployeeDto
        //    {
        //        Id = employee.Id,
        //        Name = employee.Name,
        //       Salary = employee.Salary,
        //       Address = employee.Address,
        //       Age = employee.Age,
        //       Email = employee.Email,
        //       IsActive = employee.IsActive,
        //        EmployeeType=employee.EmployeeType,

                
        //    };

        //    return View(UodateDto);
        //}
        //[HttpPost]
        //public IActionResult Update(int id, UpdatedDepartmentDto department)
        //{
        //    string message = string.Empty;
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _employeeService.Update(department);
        //            return RedirectToAction(nameof(Index));
        //        }
        //        message = "Department Can Not Update";
        //    }

        //    catch (Exception ex)
        //    {
        //        message = _env.IsDevelopment() ? ex.Message : "Department Can Not Update";
        //    }
        //    return View(department);




        //}

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            _employeeService.Remove(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
