using FluentNHibernate.Mapping;

namespace Solution.Models
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual int MobileNo { get; set; }

        public virtual IList<User>? Users{ get; set; }

    }
    public class EmployeeMapping : ClassMap<Employee>
    {
        public EmployeeMapping()
        {
            Id(x => x.Id)
                .GeneratedBy.Native()
                .Column("id");
            Map(x => x.Name)
                .Column("name");
            HasMany(x => x.Users);
            Table("Employee");
        }
    }
}
