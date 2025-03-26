

using Demo.BusinessLogic.DataTransferObject.Departments;

namespace Demo.BusinessLogic.Services.DepartmentService
{
    public interface IDepartmentService
    {
        void Add(CreatedDepartmentDto department);
        IEnumerable<DepartmentToReturnDto> GetAll();
        DepartmentDetailsDto? GetById(int? id);
         void Remove(int id);
        void Update(UpdatedDepartmentDto department);
    }
}
