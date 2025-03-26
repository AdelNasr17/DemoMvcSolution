using Demo.BusinessLogic.DataTransferObject.Departments;
using Demo.BusinessLogic.DataTransferObject.Employees;
using Demo.DataAccess.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeToReturnDto> GetAll();
        EmployeeDetailsDto? GetById(int? id);
        void Add(CreatedEmployeeDto employee);
        void Update(UpdatedEmployeeDto employee);
        bool Remove(int id);
    }
}
