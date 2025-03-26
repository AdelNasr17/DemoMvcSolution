using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Repositories.Shared;

namespace Demo.DataAccess.Repositories.Departments
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
    
    }
}