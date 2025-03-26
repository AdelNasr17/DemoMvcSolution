using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Repositories.Departments;
using Demo.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbcontext;

        public UnitOfWork(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            DepartmentRepository = new DepartmentRepository(dbcontext);
            EmployeeRepository = new EmployeeRepository(dbcontext);
        }

        public IDepartmentRepository DepartmentRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }

        public int Complete() => _dbcontext.SaveChanges();



    }
}
