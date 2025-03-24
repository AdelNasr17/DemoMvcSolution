using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Repositories.Classes;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _UnitOfWork;


        public DepartmentService(IUnitOfWork UnitOfWork) // 1.Injection
        {
            _UnitOfWork = UnitOfWork;
        }

        public void Add(Department department)
        {
            var mappedDepartment = new Department()
            {
                Code = department.Code,
                Name = department.Name,
                CreatedOn = DateTime.Now

            };
            _UnitOfWork.DepartmentRepository.Add(mappedDepartment);
            _UnitOfWork.Complete();
        }

        public IEnumerable<Department> GetAll()
        {
            return _UnitOfWork.DepartmentRepository.GetAll();

        }

        public Department GetById(int? id)
        {
            if (id is null)
                return null;
            var department = _UnitOfWork.DepartmentRepository.GetById(id.Value);
            if (department is null)
                return null;

            return department;

        }

        public void Remove(Department department)
        {
            _UnitOfWork.DepartmentRepository.Remove(department);
            _UnitOfWork.Complete();
        }

        public void Update(Department department)
        {

            //var dept = GetById(department.Id);
            //if(dept.Name != department.Name)
            //{
            //    if (GetAll().Any(D => D.Name == department.Name))
            //        throw new Exception("Duplicate Department Name");
            //}
            //dept.Name = department.Name;
            //dept.Code = department.Code;

            _UnitOfWork.DepartmentRepository.Update(department);
            _UnitOfWork.Complete();

        }

        ////Get All Departments
        //public IEnumerable<DepartmentDto> GetAllDepartments()
        //{
        //    var departments = _departmentRepository.GetAll();
        //    return departments.Select(D => D.ToDepartmentDto());
        //}

        //// Get Department By Id
        //public DepartmentDetialsDto? GetDepartmentById(int id)
        //{
        //    var department = _departmentRepository.GetById(id);
        //    /*if (department == null)
        //    //    return null;
        //    //else
        //    //{
        //    //    var departmentToReturn = new DepartmentDetialsDto()
        //    //    {
        //    //        Id = department.Id,
        //    //        Name = department.Name,
        //    //        Code = department.Code,
        //    //        Description = department.Description,
        //    //        CreatedOn = DateOnly.FromDateTime(department.CreatedOn)

        //    //    };
        //    //    return departmentToReturn;
        //    //return department is null ? null : new DepartmentDetialsDto()
        //    //{
        //    //    Id = department.Id,
        //    //    Name = department.Name,
        //    //    Code = department.Code,
        //    //    Description = department.Description,
        //    //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn)
        //    };

        //    */


        //    return department is null ? null : department.ToDepartmentDetialsDto();
        //}


        //// Greate New Department
        //public int CreateDepartment(CreatedDepartmentDto departmentDto)
        //{
        //    var department = departmentDto.ToEntity();
        //    return _departmentRepository.Add(department);
        //}


        ////Update Department 
        //public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        //{

        //    return _departmentRepository.Update(departmentDto.ToEntity());
        //}

        //// Deleted Department

        //public bool DeleteDepartment(int id)
        //{
        //    var Department = _departmentRepository.GetById(id);
        //    if (Department is null) return false;
        //    else
        //    {
        //        int Result = _departmentRepository.Remove(Department);
        //        return Result > 0 ? true : false;
        //    }
        //}
    }
}
