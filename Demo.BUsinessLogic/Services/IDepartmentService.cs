using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services
{
    public interface IDepartmentService
    {
        void Add(Department department);
        IEnumerable<Department> GetAll();
        Department GetById(int? id);
        void Remove(Department department);
        void Update(Department department);
    }
}
