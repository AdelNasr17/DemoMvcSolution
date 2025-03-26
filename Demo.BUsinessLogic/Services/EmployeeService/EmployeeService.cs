using Demo.BusinessLogic.DataTransferObject.Employees;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _UnitOfWork;

        public EmployeeService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public void Add(CreatedEmployeeDto employeeDto)
        {
            Employee Employee = new Employee
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,




            };
            _UnitOfWork.EmployeeRepository.Add(Employee);
            _UnitOfWork.Complete();


        }

        public IEnumerable<EmployeeToReturnDto> GetAll()
        {
            return _UnitOfWork.EmployeeRepository.GetAllQueryable().Where(e=> e.IsDeleted==false).Select(employee => new EmployeeToReturnDto
            {
                Id = employee.Id,
                Name= employee.Name,
                Salary= employee.Salary,
                Age= employee.Age,
                Email= employee.Email,
                Gender=employee.Gender.ToString(),
                EmployeeType=employee.EmployeeType.ToString(),
                IsActive= employee.IsActive,
            });
        }

        public EmployeeDetailsDto? GetById(int? id)
        {
          var employee=_UnitOfWork.EmployeeRepository.GetById(id);
            if (employee  is null)
                return null;

                return new EmployeeDetailsDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    Age = employee.Age,
                    Email = employee.Email,
                    Address = employee.Address,
                    HiringDate = employee.HiringDate,
                    PhoneNumber = employee.PhoneNumber,
                    Gender = employee.Gender.ToString(),
                    EmployeeType = employee.EmployeeType.ToString(),
                    IsActive = employee.IsActive,
                    CreatedBy = employee.CreatedBy,
                    CreatedOn = employee.CreatedOn,
                    LastModifiedBy = employee.LastModifiedBy,
                    LastModifiedOn = employee.LastModifiedOn,
                    IsDeleted = employee.IsDeleted,
                };
          
        }

        public bool Remove(int id)
        {
         var employee = _UnitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
                return false;
            else
            {
                _UnitOfWork.EmployeeRepository.Remove(employee);
                return true;
            }
        }

        public void Update(UpdatedEmployeeDto employeeDto)
        {
            Employee employee = new Employee
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,




            };
            _UnitOfWork.EmployeeRepository.Update(employee);
            _UnitOfWork.Complete();
        }
    }
}
