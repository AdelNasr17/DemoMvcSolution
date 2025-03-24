using Demo.DataAccess.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services
{
    public interface IEmployeeService
    {
        void Add(Employee employee);
        IEnumerable<Employee> GetAll();
        Employee GetById(int? id);
        void Remove(Employee employee);
        void Update(Employee employee);
    }
}
