using Demo.BusinessLogic.DataTransferObject.Departments;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.DepartmentService;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Repositories.Departments;
using Microsoft.AspNetCore.Mvc;

namespace Route.Demo.PL.Controllers
{
    public class DepartmentController: Controller
    {
        private readonly IDepartmentService _departmentServices;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _env;

        public DepartmentController(IDepartmentService departmentService,ILogger<DepartmentController> logger,IWebHostEnvironment env)
        {
            this._departmentServices = departmentService;
            _logger = logger;
            _env = env;
        }
        [HttpGet]   
        public IActionResult Index()
        {
            var Departments = _departmentServices.GetAll();
            ViewBag.Departments = Departments;
            var departments = _departmentServices.GetAll();

            return View(departments );
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto department)
        {
            string message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentServices.Add(department);
                    return RedirectToAction(nameof(Index));
                }
                message = "Department Can Not Created";
                ModelState.AddModelError(string.Empty, message);
                return View(department);


            }
            catch(Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                if (_env.IsDevelopment())
                {
                    message = ex.Message;
                    return View(department);
                }
                else
                {
                    message = "Department Can Not Created";
                    return View("Error", message);
                }             

            }

        }
        [HttpGet]
        public IActionResult Details(int? id,string viewName="Details")
        {
            if(id  == null)
                return BadRequest();
            var department = _departmentServices.GetById(id.Value);
            if(department is  null) 
                return NotFound();

            return View(viewName,department);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if(id is null)
                return BadRequest();//400
            var department =_departmentServices.GetById(id.Value);
            if(department is null)
                return NotFound();
            var UodateDto = new UpdatedDepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                CreateOn = department.CreatedOn,
                Description = department.Description
            };
              
                return View(UodateDto);
        }
        [HttpPost]
        public IActionResult Update(int id ,UpdatedDepartmentDto department)
        {
            string message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentServices.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                message = "Department Can Not Update";
            }

            catch (Exception ex)
            {
                message = _env.IsDevelopment() ? ex.Message : "Department Can Not Update";
            }
            return View(department);




        }

        public IActionResult Delete(int? id)
        {
          if(id == null)
                return NotFound();

            _departmentServices.Remove(id.Value);
            return RedirectToAction(nameof(Index));
        }
        //public IActionResult Delete(int? id)
        //{
        //    if (id is null)
        //        return BadRequest();
        //    var department = _departmentServices.GetById(id.Value);

        //    if(department is null)
        //        return NotFound();
        //    return View(department);
        //}
        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    string message = string.Empty;
        // try
        //    {
        //        try
        //        {
        //            _departmentServices.Remove(id);

        //        }
        //        catch
        //        {
        //            message = "An Error Happend When Deleting The Department";
        //        }

        //    }
        //    catch(Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //        message = _env.IsDevelopment() ? ex.Message : "An Error Happend When Deleting The Department";
        //    }
        //    ModelState.AddModelError(string.Empty, message);
        //    return View(nameof(Index));

        //}

    }
}
