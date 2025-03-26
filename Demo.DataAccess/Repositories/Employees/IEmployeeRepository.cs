using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Employees
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
     


    }
}
