using Demo.BusinessLogic.Services;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Route.Demo.PL.Controllers
{
    public class DepartmentController: Controller
    {
        private readonly IDepartmentService _departmentServices;

        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentServices = departmentService;
        }
        [HttpGet]   
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAll();

            return View(departments );
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentServices.Add(department);
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("Department Error", "Validation Error");
                return View(department);


            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Department Error", ex.Message);
                return View(department);

            }

        }

        public IActionResult Details(int? id,string viewName="Details")
        {
            var department = _departmentServices.GetById(id);
            if(department is  null) 
                return NotFound();

            return View(viewName,department);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            
              
                return Details(id,"Update");
        }
        [HttpPost]
        public IActionResult Update(int? id ,Department department)
        {
            if (department.Id != id.Value)
                return NotFound();

            _departmentServices.Update(department);
            return RedirectToAction(nameof(Index));

        }

        
        public IActionResult Delete(int id)
        {
            var department = _departmentServices.GetById(id);
            if (department is null)
                return NotFound();

            _departmentServices.Remove(department);
            return RedirectToAction(nameof(Index));
        }
    }
}
