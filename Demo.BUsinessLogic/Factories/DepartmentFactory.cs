using Demo.BusinessLogic.DataTransferObject;
using Demo.DataAccess.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Factories
{
    static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department D) => new DepartmentDto()
        {
            DeptId = D.Id,
            Name = D.Name,
            Code = D.Code,
            Description = D.Description,
            DateOfCreation = DateOnly.FromDateTime(D.CreatedOn)
        };

        public static DepartmentDetialsDto ToDepartmentDetialsDto(this Department D) => new DepartmentDetialsDto()
        {
            Id = D.Id,
            Name = D.Name,
            Code = D.Code,
            Description = D.Description,
            CreatedOn = DateOnly.FromDateTime(D.CreatedOn)
        };

        public static Department ToEntity(this CreatedDepartmentDto department) => new Department()
        {
            Name = department.Name,
            Code = department.Code,
            Description = department.Description,
            CreatedOn = department.DateOfCreation.ToDateTime(new TimeOnly())
        };

        public static Department ToEntity(this UpdatedDepartmentDto department) => new Department()
        {
            Id = department.Id,
            Name = department.Name,
            Code = department.Code,
            Description = department.Description,
            CreatedOn = department.DateOfCreation.ToDateTime(new TimeOnly())
        };



    }
}
