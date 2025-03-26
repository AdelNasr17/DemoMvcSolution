

using Demo.DataAccess.Models.Shared.Enums;

namespace Demo.DataAccess.Data.Configurations
{
    internal class EmployeeConfigurations : BaseEntityConfiguration<Employee>, IEntityTypeConfiguration<Employee>
    {
        public  void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Id).UseIdentityColumn(1, 1);
            builder.Property(E => E.Name).HasColumnType("nvarchar(50)");
            builder.Property(E => E.Address).HasColumnType("nvarchar(150)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");
            builder.Property(E => E.Gender)
                   .HasConversion((EmpGender) => EmpGender.ToString(),//Data Storage in database
                            (_gender) =>(Gender) Enum.Parse(typeof(Gender), _gender));// return the data to database
            builder.Property(E => E.EmployeeType)
                   .HasConversion((EmpType) => EmpType.ToString() , //Data Storage in database
                                  (_Type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), _Type));// return the data to database

            base.Configure(builder);



        }
    }
}
