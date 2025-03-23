using Demo.DataAccess.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.DataTransferObject
{
    public class DepartmentDetialsDto
    {
        //Constructor Mapping
        //public DepartmentDetialsDto(Department department)
        //{

        //    Id = department.Id;
        //    Name = department.Name;
        //    Code = department.Code;
        //    Description = department.Description;
        //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn);
        //}
        public int Id { get; set; } //PK
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public int CreatedBy { get; set; } //UserId
        public DateOnly CreatedOn { get; set; }
        public int LastModifiedBy { get; set; } //UserId
        public DateOnly LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; } // Soft Delete
    }
}
