using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.BusinessLogic.Services
{
    public interface IDepartmentService
    {
        int Add(Department department);
        IEnumerable<Department> GetAll();
        Department GetById(int? id);
        int Remove(Department department);
        int Update(Department department);
    }
}
