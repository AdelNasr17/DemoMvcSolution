
using Demo.BusinessLogic.DataTransferObject.Departments;
using Demo.BusinessLogic.Factories;
using Microsoft.EntityFrameworkCore;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _UnitOfWork;


        public DepartmentService(IUnitOfWork UnitOfWork) // 1.Injection
        {
            _UnitOfWork = UnitOfWork;
        }

        public void Add(CreatedDepartmentDto departmentDto)
        {
            // CreatedDepartmentDto=> Department
            var department = new Department
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.CreateOn.ToDateTime(new TimeOnly())
            };

            _UnitOfWork.DepartmentRepository.Add(department);
            _UnitOfWork.Complete();
        }

        public IEnumerable<DepartmentToReturnDto> GetAll()
        {
            // Department -> DepartmentToReturnDto
          var department = _UnitOfWork.DepartmentRepository.GetAllQueryable()
                .Select(D => new DepartmentToReturnDto
                {
                    Id = D.Id,
                    Name = D.Name,
                    Code = D.Code,
                    Description = D.Description,
                    DateOfCreation = DateOnly.FromDateTime(D.CreatedOn)
                }).AsNoTracking().ToList();

           return department;
        }

        public DepartmentDetailsDto? GetById(int? id)
        {
            // Department(id) -> DepartmentDetailsDto(id)
            var department = _UnitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
                return null;
            else
            {
                return new DepartmentDetailsDto
                {
                    Id = department.Id,
                    Name = department.Name,
                    Code = department.Code,
                    Description = department.Description,
                    CreatedOn = DateOnly.FromDateTime(department.CreatedOn)
                };
            }
              
                                

            //if (id is null)
            //    return null;
            //var department = _UnitOfWork.DepartmentRepository.GetById(id.Value);
            //if (department is null)
            //    return null;

            //return department;

        }


        public void Remove(int id)
        {
            var department = _UnitOfWork.DepartmentRepository.GetById(id);

            if (department == null)
                throw new Exception("No Deleted");

            else
            {
                _UnitOfWork.DepartmentRepository.Remove(department);
            }
            _UnitOfWork.Complete();
        }

    

        public void Update(UpdatedDepartmentDto departmentDto)
        {

            //var dept = GetById(department.Id);
            //if(dept.Name != department.Name)
            //{
            //    if (GetAll().Any(D => D.Name == department.Name))
            //        throw new Exception("Duplicate Department Name");
            //}
            //dept.Name = department.Name;
            //dept.Code = department.Code;
            var department = new Department
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.CreateOn.ToDateTime(new TimeOnly())
            };

            _UnitOfWork.DepartmentRepository.Update(departmentDto.ToEntity());
          
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
